using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveBetweenPoints : MonoBehaviour
{
    // ������ �����
    public Transform[] points;

    // �������� �������� ������� � �������� ���������� � �������
    public float speed = 1f;

    // �������� ����� ������� �������� � ��������
    public float delay = 3f;

    // ������� ����� �������
    private int currentPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // �������� ����� ������� ��������
        StartCoroutine(MoveAfterDelay(delay));
    }

    // ������� ��� ����������� �������
    IEnumerator MoveObjectToNextPoint(Transform currentPoint, Transform nextPoint)
    {
        // ��������� ���������� ����� ������� � ��������� �������
        float distance = Vector3.Distance(currentPoint.position, nextPoint.position);

        // ��������� �����, ����������� ��� ����������� ������� ����� ������� � ��������� �������
        float time = distance / speed;

        // ���������� ������ � ��������� �����
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(currentPoint.position, nextPoint.position, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ������������� ��������� ����� ��� �������
        currentPointIndex++;

        // ���� ������� ����� �������� ���������, �� ���������� ������ �� ������ �����
        if (currentPointIndex >= points.Length)
        {
            currentPointIndex = 0;
            
            

        }

        // ��������� ����������� � ��������� �����
        StartCoroutine(MoveObjectToNextPoint(nextPoint, points[currentPointIndex]));
    }

    // ������� ��� ������� ����������� ������� ����� ��������
    IEnumerator MoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveObjectToNextPoint(points[currentPointIndex], points[(currentPointIndex + 1) % points.Length]));
    }
}
