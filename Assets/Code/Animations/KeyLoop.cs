public class KeyLoop
{
    private int _startKey;
    private int _finishKey;
    private int _currentKey;

    public KeyLoop()
    {
    }

    public KeyLoop(int startKey, int finishKey)
    {
        _startKey = startKey;
        _finishKey = finishKey;
        _currentKey = _startKey;
    }

    public void SetKeyLoop(KeyLoop reference)
    {
        _startKey = reference._startKey;
        _finishKey = reference._finishKey;
        _currentKey = _startKey;
    }

    public int GetNextKey()
    {
        _currentKey++;
        if (_currentKey > _finishKey)
        {
            _currentKey = _startKey;
        }

        return _currentKey;
    }
}