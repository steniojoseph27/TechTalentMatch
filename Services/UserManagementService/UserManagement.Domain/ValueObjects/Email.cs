using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.ValueObjects
{
    public class Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrEmpty(value) || !value.Contains("@"))
                throw new ValidationException("Invalid email address.");

            Value = value;
        }

        public static implicit operator string(Email email) => email.Value;
    }
}
