using banking_app.DataAccess.Contexts;
using banking_app.DataAccess.DAOs;
using banking_app.DataAccess.Dtos;
using banking_app.Service.Interfaces;
using banking_app.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking_app.Business.Service
{
    public class UserService: IService
    {
        private UserDAO userDAO;
        private UserRegisterForm userForm;
        private SignInForm signInForm;
        private WelcomeForm welcomeForm;

        public UserService(ProjectContext clientContext)
        {
            this.userDAO = new UserDAO(clientContext);
            this.userForm = new UserRegisterForm();
            this.signInForm = new SignInForm();
            this.welcomeForm = new WelcomeForm();
        }

        public UserDTO getUserById(int id)
        {
            UserDTO user = this.userDAO.GetById(id);
            return user;
        }

        public List<UserDTO> GetAllUsers()
        {
            return this.userDAO.GetAll();
        }

        public int getUserIdByEmail(String email)
        {
            return this.userDAO.GetUserIdFromEmail(email);
        }

        public UserDTO CreateNewUser(string fullName,int sin, string passwordHash, string email, string phoneNumber)
        {
            UserDTO newUser = new UserDTO(fullName, sin, passwordHash, email, phoneNumber);
            this.userDAO.SaveNewUser(newUser);
            CloseUserCreationForm();
            MessageBox.Show("you have successully register!");
            return newUser;

        }

        public void DeleteUser(UserDTO user)
        {
            this.userDAO.DeleteUser(user);
        }

        public void UpdateUser(UserDTO user, string fullName, int sin, string email, string phoneNumber)
        {
            user.SIN = sin;
            user.FullName = fullName;
            user.Email = email;
            user.PhoneNumber = phoneNumber;
            this.userDAO.SaveModification(user);
            MessageBox.Show("You have successfully update your information");
        }

        public Boolean CheckEmailExist(string email)
        {
            if (this.userDAO.GetByEmail(email) == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckLogIn(string Email, string Password)
        {

            if (this.userDAO.GetLogIn(email: Email, PasswordHash: Password) == null)
            {
                MessageBox.Show("Email or password is not correct!");
            } else
            {
                CloseSignInForm();
                this.welcomeForm.FillData(userDAO.GetByEmail(Email));
                OpenWelcomeForm();

            }
        }

        public void OpenUserCreationForm()
        {
            this.userForm.ShowDialog();
        }

        public void CloseUserCreationForm()
        {
            this.userForm.DialogResult = DialogResult.Cancel;
        }

        public void OpenSignInForm()
        {
            this.signInForm.ShowDialog();
            
        }

        public void CloseSignInForm()
        {
            this.signInForm.Close();
        }

        public void OpenWelcomeForm()
        {
            this.welcomeForm.ShowDialog();
        }

      
    }
}
