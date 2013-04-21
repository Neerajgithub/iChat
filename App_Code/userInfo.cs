public class userInfo
{
	public userInfo() {}

    private long _userId;
    public long UserId { get { return _userId; } set { _userId = value; } }

    private string _userName;
    public string UserName { get { return _userName; } set { _userName = value; } }

    private string _email;
    public string Email { get { return _email; } set { _email = value; } }

    private string _about;
    public string About { get { return _about; } set { _about = value; } }
}