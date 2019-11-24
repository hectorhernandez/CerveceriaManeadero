using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using CerveceriaManeadero.Services;

namespace CerveceriaManeadero
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText etUsername;
        EditText etPassword;

        Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            etUsername = FindViewById<EditText>(Resource.Id.etUsername);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            btnLogin.Click += BtnLogin_Click;


            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) =>
            {
                if (certificate.Issuer.Equals("CN=localhost"))
                    return true;
                return sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
            };

        }

        private async void BtnLogin_Click(object sender, System.EventArgs e)
        {
            string username = etUsername.Text;
            string password = etPassword.Text;

            var userService = new UserService();
            var result = await userService.Login(username, password);

            if (result != null)
            {
                Toast.MakeText(this, "Ingresaste: " +result.Id, ToastLength.Long);
            }

        }
    }
}

    