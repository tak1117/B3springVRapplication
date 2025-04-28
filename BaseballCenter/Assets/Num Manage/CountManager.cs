using UnityEngine;

public class CountManager : MonoBehaviour
{
    public static CountManager Instance { get; private set; }

    [SerializeField] private TextMesh countText3D; // 3D�e�L�X�g�p
    private int count = 20; // �c�苅��

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }
    }

    private void Start()
    {
        // count ���Q�[���J�n���ɕK�� 20 �ɏ�����
        count = 20;

        // countText3D ���`�F�b�N���āAnull �̏ꍇ�͐V�����쐬
        if (countText3D == null)
        {
            CreateCountText3D();
        }

        UpdateCountText();
    }

    // countText3D �� null �̏ꍇ�ɐV�����쐬
    private void CreateCountText3D()
    {
        // ���łɃV�[���ɑ��݂��Ă��� "CountText3D" ��T��
        GameObject textObj = GameObject.Find("CountText3D");

        if (textObj == null)
        {
            // ���݂��Ȃ��ꍇ�͐V�K�ɍ쐬
            textObj = new GameObject("CountText3D");
            textObj.transform.position = new Vector3(2, 2, 0); // �ʒu�𒲐�
            countText3D = textObj.AddComponent<TextMesh>();
            countText3D.fontSize = 50;
            countText3D.color = Color.yellow;
        }
        else
        {
            countText3D = textObj.GetComponent<TextMesh>();
        }

        if (countText3D == null)
        {
            Debug.LogError("Failed to initialize countText3D!");
        }
    }

    // �J�E���g�����炷���\�b�h
    public void DecreaseCount()
    {
        count--;
        UpdateCountText();
    }

    // count �݂̂����Z�b�g����
    public void ResetCount()
    {
        count = 20;
        UpdateCountText();
    }

    // �e�L�X�g���X�V
    private void UpdateCountText()
    {
        // countText3D �� null �̏ꍇ�A�V�����쐬
        if (countText3D == null)
        {
            CreateCountText3D();
        }

        countText3D.text = "Pitches : " + count;
    }
}
