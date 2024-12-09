using uagrm_sig.CoosivApp.Infrastructure.DTOs.Common;

namespace uagrm_sig.CoosivApp.Infrastructure.DTOs.CoosivWebService;

public class ValidarLoginPasswordRequest : ISoapRequest
{
    public string lsLogin { get; set; }
    public string lsPassword { get; set; }

    public string ToSoapBody()
    {
        return $@"<ValidarLoginPassword xmlns=""http://tempuri.org/"">
                      <lsLogin>{lsLogin}</lsLogin>
                      <lsPassword>{lsPassword}</lsPassword>
                  </ValidarLoginPassword>";
    }
}