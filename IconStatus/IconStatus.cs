using com.tok.mika.libs.mws;
using com.tok.mika.libs.mws.module;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace com.tok.mika.project.mws.IconStatus
{
    public class IconStatus : Module
    {
        int version = 0;
        int subversion = 1;
        public int GetDefaultLavel()
        {
            return 1;
        }

        public string getName()
        {
            return "IconStatus v." + version.ToString() + "." + subversion.ToString();
        }

        public string getShortName()
        {
            return "IconStatus";
        }

        public void onDisable()
        {
            
        }

        public void onEnable()
        {
            
        }

        public void onLoad(MainDataServer mainData)
        {
            
        }

        public bool tick(Microsoft.AspNetCore.Http.HttpContext context, List<APIData>? apiData = null)
        {
            if (context != null && context.Request != null)
            {
                string patch = context.Request.Path;
                if (patch.Equals("favicon") || patch.Equals("/favicon"))
                {
                    //Обработка запросов на изменение в таблице
                    if (context.Request.Method.Equals("GET", StringComparison.OrdinalIgnoreCase))
                    {
                        IQueryCollection query = context.Request.Query;
                        var response = context.Response;
                        byte[]? buffer = null;
                        if (query["c"] != StringValues.Empty)
                        {
                            buffer = System.Text.Encoding.UTF8.GetBytes("test " + query["c"]);

                            response.ContentType = "application/json";
                            response.StatusCode = 200;
                            try
                            {
                                response.Body.WriteAsync(buffer, 0, buffer.Length);
                            }
                            catch (Exception exp)
                            {
                                Console.Write(exp.ToString());
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void unLoad()
        {

        }
    }
}
