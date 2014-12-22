using UnityEngine;

public class ComportamentoTecla: MonoBehaviour
{
    public int Nota;
    private bool enter;
    private SanfordHelper somHelper;
    private float yBackup;

    void Start ()
	{
	    enter = false;
        somHelper = new SanfordHelper();
		yBackup = transform.localPosition.y;
	}
	
	void Update () {
        
	    var rotacaoZ = transform.rotation.eulerAngles.z;
        if (rotacaoZ < 180)
	    {
	        Soltou();
            transform.rotation = Quaternion.Euler(0,0,0);
			transform.localPosition = new Vector3(transform.localPosition.x, yBackup, transform.localPosition.z);
			rigidbody.Sleep();
	    }
        if (rotacaoZ > 180)
	    {
	        rigidbody.AddRelativeTorque(0, 0, (360 - rotacaoZ) * Time.deltaTime * 20);
	        if (rotacaoZ < 359)
	        {
	            if (!enter)
	                Entrou();
                //else
	            //    Presionando();
	        }
	    }
	}

    private void Entrou()
    {
        enter = true;
        somHelper.Play(Nota);
    }

    private void Presionando()
    {
        
    }

    private void Soltou()
    {
        enter = false;
        somHelper.Stop(Nota);
    }
}