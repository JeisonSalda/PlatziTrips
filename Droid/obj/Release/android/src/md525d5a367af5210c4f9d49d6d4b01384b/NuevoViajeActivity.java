package md525d5a367af5210c4f9d49d6d4b01384b;


public class NuevoViajeActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("PlatziTrips.Droid.NuevoViajeActivity, PlatziTrips.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NuevoViajeActivity.class, __md_methods);
	}


	public NuevoViajeActivity ()
	{
		super ();
		if (getClass () == NuevoViajeActivity.class)
			mono.android.TypeManager.Activate ("PlatziTrips.Droid.NuevoViajeActivity, PlatziTrips.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
