using UnityEngine;
using System.Collections;

// DisablePlayer��ũ��Ʈ�� disable (), enable () �� ����Ͽ� ȭ��ȸ���߿� ĳ���� �������� ���߰��ϰ� ȸ���� ������ �ٽ� �����̵�����
// ȸ���Ҷ����� crunchCollidersToPlayer() [�÷��� �ݶ��̴� ��ġ ����] �Լ��� ��������
class CameraRotator : MonoBehaviour // ī�޶� ȸ����� Ŭ���� (CrunchPlatformColliders, DisablePlayer�� �����Ǵ� Ŭ����) + �÷����� �ݶ��̴� ��ġ �������ִ� Ŭ����
{
    public bool turn = false;
    public int RotationAngle = 0;

    private PlayerMove PlayerMove = null; // PlayerMove��� PlayerMove ����
    private GameObject Player = null;
    private GameObject Obstacle = null;
    private GameObject[] allPlatforms = null;

    private float rotateTime = 1.0f; // ī�޶� ȸ���ð�
    private bool isTweening = false; // ī�޶� ȸ�� ���� (ī�޶� ȸ�����ִ� iTween�۵� ���θ� �Ǵ��ϱ����� ���������)

    private void Start()
    {
        RotationAngle = 0;
        turn = false;
        Player = GameObject.FindGameObjectWithTag("Player"); // "Player"��� �̸��� Tag�� ���� ���ӿ�����Ʈ�� ã�Ƽ� player��� ����
        Obstacle = GameObject.Find("Obstacle");
        allPlatforms = GameObject.FindGameObjectsWithTag("Platform");
        PlayerMove = Player.GetComponentInChildren<PlayerMove>();
        setPlayerPos(); // ĳ������ġ ����
        crunchCollidersToPlayer(); // ĳ������ġ�� ���� �ݶ��̴� ��ġ ����
    }

    private void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Input.GetKeyDown(KeyCode.Z)) // ZŰ�� �����ٸ�
        {
            rotateTween(90); // 90�� ȸ�� (ī�޶� ȸ����Ű�� �Լ� ����)
        }
        if (Input.GetKeyDown(KeyCode.X)) // xŰ�� �����ٸ�
        {
            rotateTween(-90); // -90�� ȸ�� (ī�޶� ȸ����Ű�� �Լ� ����)
        }
    }

    private void rotateTween(float amount) // ITween�� ����Ͽ� ī�޶� ȸ����Ű�� �Լ� (amount��� float�� ī�޶� ȸ�� ����)
    {
        if (isTweening == false) // ī�޶� ȸ�� ���� �� �����϶�
        {
            isTweening = true; // ī�޶� ȸ�� ���� ��
            setPlayerPos(); // ȸ���� ���� ĳ���� ��ġ ����
            PlayerMove.disable(); // ĳ���� �������� ����
            Vector3 rot = new Vector3(0, amount, 0); // y������ amount�� rot��� Vector3�� ����
            // ȸ���ϴ� iTween��� (RotateAdd) ���
            iTween.RotateAdd
                (gameObject, iTween.Hash // �־��� ���Ϸ� ���� �־��� �ð��� ���� ȸ����Ű�� ���
                    (
                    "time", rotateTime, // time, rotateTime -> ī�޶� ȸ���ð� [�ִϸ��̼��� �Ϸ�Ǵµ� �ɸ��� �ð�]
                    "amount", rot, // amount, rot -> Vector3 ȸ�� [GameObject�� ���� ȸ���� �߰� �� ���Ϸ� ���� ����]
                    "easetype", iTween.EaseType.easeInOutSine, // easetype, -> iTween.EaseType.easeInOutSine easeInOutSine�̶�� ������� ȸ�� [�ִϸ��̼ǿ� ����� ����]
                    "oncomplete", "onColorTweenComplete" // oncomplete->iTween �ִϸ��̼��� �����ڿ� onColorTweenComplete��� �̸��� �Լ� ���� [�ִϸ��̼��� ������ ���۵� �Լ��� �̸�]
                    )
                );
            ObstacleOff();
            Turning();
            RotationWorld();

            //GameObject.Find("rotation").GetComponent<AudioSource>().Play();

        }
    }

    private void onColorTweenComplete()
    {
        isTweening = false; // ī�޶� ȸ�� ���� ����
        PlayerMove.enable(); // ĳ���� ������ �������ֱ�
        crunchCollidersToPlayer(); // �÷��� �ݶ��̴��� ĳ������ǥ�� ��ġ ����
        ObstacleOn();
    }

    public void RotateButton()
    {
        rotateTween(90); // 90�� ȸ�� (ī�޶� ȸ����Ű�� �Լ� ����)
    }

    private void setPlayerPos() // ȸ���� ���� ĳ���� ��ġ ����
    {
        // player��� ����ȿ�����Ʈ�� ��ġ������ Vector3.down(0, -1, 0) * 100 ��ġ�� �������� ������ ���� ray�� ����
        Ray ray = new Ray(Player.transform.position, Vector3.down);
        RaycastHit hit = new RaycastHit(); // Ray�� �浹�Ǿ��ٴ°��� �˼��ְ� ���ִ� ��ġ 
        // ray�� 100.0f���̸�ŭ �߻�Ǿ� �浹�ȴٸ� -> (ray(Ray �߻��� ��ġ, Ray �߻� ����), �浹���(out�� �������ִ� �����̰� hit�� �⵿���� Ȯ��), Ray�� �߻�Ǵ� �ִ����)
        // out�� ����Ҷ� �ڿ��ð��� �̸� ����Ǿ� �־�߸� �Ѵ�. (�ٷ� �տ� RaycastHit hit = new RaycastHit(); ������ �ִ� ����)
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            GameObject platform = hit.collider.gameObject; // ray�� �浹�� �ݶ��̴��� ���� ���ӿ�����Ʈ�� platform�̶�� �̸��� ���ӿ�����Ʈ�� ����
            Vector3 colliderPos = ((BoxCollider)hit.collider).center; // ray�� �浹�� (BoxCollider)�ݶ��̴��� �߽���ǥ�� colliderPos��� Vector3�������� ����
            // ray�� �浹�� �÷��� ��ǥ�� (ĳ������ ��ġ��ǥ�� ������ǥ���� ������ǥ�� ��ȯ�� ��ǥ)�� ��ȯ�� ��ǥ�� playerPos��� Vector3�� ����
            Vector3 playerPos = platform.transform.InverseTransformPoint(Player.transform.position);
            // ĳ����(������ǥ)�� x, z��ǥ���� �ݶ��̴��� x, z��ǥ�� �Ÿ��� ����(y��ǥ�� ĳ������ǥ �״��)�� newPos��� Vector3�� ���� 
            Vector3 newPos = new Vector3(playerPos.x - colliderPos.x, playerPos.y, playerPos.z - colliderPos.z);
            newPos = platform.transform.TransformPoint(newPos); // (newPos)��� ������ǥ�� ������ǥ�� ������ �ٲ����� ���� ��ǥ�� newPos�� ����
            Player.transform.position = newPos; // ĳ������ǥ�� newPos�� �̵�
        }
    }

    private void crunchCollidersToPlayer() // �÷��� �ݶ��̴��� ĳ������ǥ�� ��ġ ����
    {
        Transform playerTrans = Player.transform; // ĳ������ transform (��ġ, ȸ��, ũ�� ����)�� playerTrans��� �̸����� ����
        allPlatforms = GameObject.FindGameObjectsWithTag("Platform"); // "Platform"��� �̸��� Tag�� ���� ���ӿ�����Ʈ�� ��� ã�Ƽ� allPlatforms ��� �迭�� ����
        int numPlatforms = allPlatforms.Length; // "Platform"��� �̸��� ���� �÷����� ������ numPlatforms�� ����
        for (int i = 0; i < numPlatforms; i++)
        { // �ݺ��� (�÷��� ������ŭ)
            GameObject platform = allPlatforms[i]; // platform �̸��� ���ӿ�����Ʈ�� allPlatforms[i��°]�� ����
            // ������ �÷����� ������Ʈ�� BoxCollider�� �����ͼ� collider��� �̸��� Boxcollider�� ���� 
            BoxCollider collider = platform.GetComponentInChildren<BoxCollider>();
            collider.center = Vector3.zero; // collider�� �߽��� Vector3.zero(0, 0, 0)���� ����

            //convert pos vec into world space
            // �÷����� BoxCollider�� �߽���ġ�� colliderPos��� Vector3�� ����
            Vector3 colliderPos = collider.transform.TransformPoint(collider.center);
            Vector3 playerPos = playerTrans.position; // ĳ������ ��ġ�� playerPos��� Vector3�� ����
            Vector3 newColliderPos; // �� �÷��� Collider�� ��ġ�� ���� // �� Vector3�� ĳ������ ��ǥ�� �÷����� ��ǥ�Ϻΰ� ������

            //move platform collider depending on what side the camera is facing 
            Vector3 normalCam = Camera.main.transform.position.normalized;
            // (normalCam -> ī�޶� ��ġ ����ȭ)
            if (Mathf.Abs(Mathf.Round(normalCam.x)) == 1.0f) // normalCam.x�� �ݿø��� ���� ���밪�� 1�̸�
                newColliderPos = new Vector3(playerPos.x, colliderPos.y, colliderPos.z);
            else
                newColliderPos = new Vector3(colliderPos.x, colliderPos.y, playerPos.z);

            //converts back into local space
            newColliderPos = collider.transform.InverseTransformPoint(newColliderPos);
            collider.center = newColliderPos; // �ݶ��̴� �߽��� newColliderPos
        }
    }

    private void Turning()
    {
        if (turn == false)
        {
            turn = true;
        }
        else
            turn = false;
    }

    private void RotationWorld()
    {
        RotationAngle = RotationAngle + 90;
        if (RotationAngle >= 360)
        {
            RotationAngle = 0;
        }
    }

    private void ObstacleOff()
    {
        foreach (Transform child in Obstacle.transform)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void ObstacleOn()
    {
        foreach (Transform child in Obstacle.transform)
        {
            child.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
