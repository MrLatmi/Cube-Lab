using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveBetweenPoints : MonoBehaviour
{
    // массив точек
    public Transform[] points;

    // скорость движения объекта в единицах расстояния в секунду
    public float speed = 1f;

    // задержка перед началом движения в секундах
    public float delay = 3f;

    // текущая точка объекта
    private int currentPointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // задержка перед началом движения
        StartCoroutine(MoveAfterDelay(delay));
    }

    // функция для перемещения объекта
    IEnumerator MoveObjectToNextPoint(Transform currentPoint, Transform nextPoint)
    {
        // вычисляем расстояние между текущей и следующей точками
        float distance = Vector3.Distance(currentPoint.position, nextPoint.position);

        // вычисляем время, необходимое для перемещения объекта между текущей и следующей точками
        float time = distance / speed;

        // перемещаем объект к следующей точке
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(currentPoint.position, nextPoint.position, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // устанавливаем следующую точку как текущую
        currentPointIndex++;

        // если текущая точка является последней, то перемещаем объект на первую точку
        if (currentPointIndex >= points.Length)
        {
            currentPointIndex = 0;
            
            

        }

        // запускаем перемещение к следующей точке
        StartCoroutine(MoveObjectToNextPoint(nextPoint, points[currentPointIndex]));
    }

    // функция для запуска перемещения объекта после задержки
    IEnumerator MoveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MoveObjectToNextPoint(points[currentPointIndex], points[(currentPointIndex + 1) % points.Length]));
    }
}
