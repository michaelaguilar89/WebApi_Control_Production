namespace WebApi_Control_Production.aws
{
	public class LambdaFunction : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
	{
		protected override void Init(IWebHostBuilder builder)
		{
			builder.UseContentRoot(Directory.GetCurrentDirectory())
				.UseLambdaServer()
				.UseApiGateway();
		}
	}
}
