namespace Infra.Resources
{
    public class Messages
    {
        // Game
        public const string GAME_NAME_REQUIRED = "Campo nome é obrigatório";
        public const string GAME_NAME_LENGTH = "O campo nome deve ter entre 2 e 120 caracteres";
        public const string GAME_DELETE = "Não é possível excluir um jogo já foi emprestado";

        // Friend
        public const string FRIEND_NAME_REQUIRED = "Campo nome é obrigatório";
        public const string FRIEND_NAME_LENGTH = "O campo nome deve ter entre 2 e 120 caracteres";
        public const string FRIEND_NICKNAME_LENGTH = "O campo apelido deve ter entre 2 e 120 caracteres";
        public const string FRIEND_EMAIL_ERROR = "Campo e-mail está inválido";
        public const string FRIEND_DELETE = "Não é possível excluir um amigo que para quem você já emprestou um jogo";

        // User
        public const string USER_LOGIN_ERROR = "Usuário ou senha inválidos";
    }
}
