using SimpleFuzzy.Abstract;

public class ObjectSet : IObjectSet
{
    private double currentObject;
    private readonly double minValue;
    private readonly double maxValue;
    private readonly double step;

    public bool Active { get; set; }
    public string Name { get; private set; }

    // Конструктор для задания базового множества
    public ObjectSet(string name, double minValue, double maxValue, double step)
    {
        Name = name;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.step = step;

        currentObject = minValue;
    }

    // Извлечение текущего объекта
    public object Extraction()
    {
        return currentObject;
    }

    // Переход к следующему объекту
    public void MoveNext()
    {
        if (IsEnd())
        {
            throw new InvalidOperationException("Текущий элемент последний. Переход к следующему невозможен");
        }
        else
        {
            currentObject += step;
        }
    }

    // Возврат к первому элементу
    public void ToFirst()
    {
        currentObject = minValue;
    }

    // Проверка, достигнут ли конец множества
    public bool IsEnd()
    {
        return currentObject > maxValue;
    }
}