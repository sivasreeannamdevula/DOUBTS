class KeyExistsException:Exception
{
    public override string Message
    {
        get
        {
            return "Key ALready found";
        }
    }
}