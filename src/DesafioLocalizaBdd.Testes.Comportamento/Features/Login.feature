Funcionalidade: Login
	Sendo um usuário
	Quero poder efetuar login no sistema
	Para que eu possa ter acesso a funcionalidades restritas conforme o meu perfil	

Cenário: usuário efetua login informando CPF e senha corretos
	Dado que o usuário informou o login '09784494604' e a senha '123456'
	E que os dados de entrada estão válidos e correspondem a um cliente cadastrado
	Então o usuário será autenticado como um cliente
	
Cenário: usuário efetua login informando Matrícula e senha corretos
	Dado que o usuário informou o login '130364' e a senha '123456'
	E que os dados de entrada estão válidos e correspondem a um operador do sistema
	Então o usuário será autenticado como um operador do sistema
