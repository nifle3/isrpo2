namespace WebApplication2.Models;

public class Array
{
    private List<int> _array;

    public Array() =>
        _array = new List<int>();

    public IEnumerable<int> GetArray =>
        _array;

    public int AverageValue { get; private set;  }

    public void GenerateArray(int size = 16)
    {
        _array = new List<int>();
        
        var rnd = new Random();
        for (var i = 0; i < size; i++)
            _array.Add(rnd.Next(-10, 30));
    }

    public void CalculateAverageValue() =>
        AverageValue = _array.Where(p => p > 0).Sum() / _array.Count(p => p > 0);
}