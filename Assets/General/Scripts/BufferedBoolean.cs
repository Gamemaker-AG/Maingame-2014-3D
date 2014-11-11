
public class BufferedBoolean
{
    public bool previousValue { private set; get; }
	public bool value { private set; get; }
    public bool hasBecomeTrue
    {
        get
        {
            return value && !previousValue;
        }
    }
    public bool hasBecomeFalse
    {
        get
        {
            return !value && previousValue;
        }
    }

    public void Update(bool newValue)
    {
        previousValue = value;
        value = newValue;
    }
}
