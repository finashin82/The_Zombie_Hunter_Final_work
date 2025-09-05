using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private CinemachineCamera freeLookCamera;

    private InputData inputData;
    private Animator animator;
    private Rigidbody rb;
    private Vector3 moveDirection;

    void Start()
    {
        inputData = GetComponent<InputData>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        animator.SetFloat("x", inputData.inputVector.x);
        animator.SetFloat("y", inputData.inputVector.y);
    }

    private void FixedUpdate()
    {
        RotationBehindCamera();

        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }

    /// <summary>
    /// Вращение персонажа в направлении камеры
    /// </summary>
    private void RotationBehindCamera()
    {
        // Получаем направление камеры
        Vector3 cameraForward = freeLookCamera.transform.forward;
        Vector3 cameraRight = freeLookCamera.transform.right;

        // Игнорируем вертикальную составляющую (наклон камеры вверх/вниз)
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Поворачиваем объект по направлению камеры, чтобы он постоянно смотрел вперед
        Vector3 dir = new Vector3(cameraForward.x, 0, cameraForward.z);
        transform.rotation = Quaternion.LookRotation(dir);

        // Вычисляем направление движения относительно камеры
        moveDirection = (cameraForward * inputData.inputVector.y + cameraRight * inputData.inputVector.x).normalized;
    }
}
