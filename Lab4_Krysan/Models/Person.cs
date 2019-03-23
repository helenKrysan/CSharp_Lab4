using System;
using Lab4_Krysan.Tools.Exception;
using System.ComponentModel.DataAnnotations;
using Lab4_Krysan.Tools.Managers;

namespace Lab4_Krysan.Models
{
    [Serializable]
    class Person
    {
        private Guid _guid;
        private DateTime _dateOfBirth;
        private string _name;
        private string _surname;
        private string _email;

        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            if (DateTime.Now < dateOfBirth)
            {
                throw new FutureInputDateException();
            }
            if (!new EmailAddressAttribute().IsValid(email))
            {
                throw new InvalidEmailException();
            }
            _name = name;
            _surname = surname;
            _email = email;
            _dateOfBirth = dateOfBirth;
            _sunSign = DeterminateSign();
            _chineseSign = DeterminateChineaseSign();
            _isAdult = IsAdultImpl();
            _isBirthday = IsBirthdayImpl();
            var checkAge = CountAge();
        }

        public Person(string name, string surname, string email)
        {
            if (!new EmailAddressAttribute().IsValid(email))
            {
                throw new InvalidEmailException();
            }
            _name = name;
            _surname = surname;
            _email = email;
            _sunSign = DeterminateSign();
            _chineseSign = DeterminateChineaseSign();
            _isAdult = IsAdultImpl();
            _isBirthday = IsBirthdayImpl();
            var checkAge = CountAge();
        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            if (DateTime.Now < dateOfBirth)
            {
                throw new FutureInputDateException();
            }
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
            _sunSign = DeterminateSign();
            _chineseSign = DeterminateChineaseSign();
            _isAdult = IsAdultImpl();
            _isBirthday = IsBirthdayImpl();
            var checkAge = CountAge();
        }

        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            private set
            {
                _dateOfBirth = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }


        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if(!String.IsNullOrWhiteSpace(value))
                {
                    _surname = value;
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (new EmailAddressAttribute().IsValid(value))
                {
                    _email = value;
                }
            }
        }

        private bool _isAdult;
        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }

        }

        private string _sunSign;
        public string SunSign
        {
            get
            {
                return _sunSign;
            }
        }

        private string _chineseSign;
        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
        }

        private bool _isBirthday;
        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
        }

        private bool IsAdultImpl()
        {
            if (CountAge() >= 18) return true;
            return false;
        }

        private bool IsBirthdayImpl()
        {
            if (DateTime.Now.Month == _dateOfBirth.Month && DateTime.Now.Day == _dateOfBirth.Day)
            {
                return true;
            }
            return false;
        }

        private int CountAge()
        {
            DateTime now = DateTime.Today;
            int age = 0;

            if (now.Month < _dateOfBirth.Month || now.Day < _dateOfBirth.Day)
            {
                age = now.Year - _dateOfBirth.Year - 1;
            }
            else
            {
                age = now.Year - _dateOfBirth.Year;
            }

            if (age > 135) throw new LivePersonRequireException();

            return age;
        }

        private string DeterminateSign()
        {
            int day = _dateOfBirth.Day;
            string sign = "";
            switch (_dateOfBirth.Month)
            {
                case 1:
                    {
                        if (day >= 1 && day <= 19)
                        {
                            sign = "Capricorn";
                        }
                        else sign = "Aquarius";
                        break;
                    }
                case 2:
                    {
                        if (day >= 1 && day <= 18)
                        {
                            sign = "Aquarius";
                        }
                        else sign = "Pisces";
                        break;
                    }
                case 3:
                    {
                        if (day >= 1 && day <= 20)
                        {
                            sign = "Pisces";
                        }
                        else sign = "Aries";
                        break;
                    }
                case 4:
                    {
                        if (day >= 1 && day <= 19)
                        {
                            sign = "Aries";
                        }
                        else sign = "Taurus";
                        break;
                    }
                case 5:
                    {
                        if (day >= 1 && day <= 20)
                        {
                            sign = "Taurus";
                        }
                        else sign = "Gemini";
                        break;
                    }
                case 6:
                    {
                        if (day >= 1 && day <= 20)
                        {
                            sign = "Gemini";
                        }
                        else sign = "Cancer";
                        break;
                    }
                case 7:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Cancer";
                        }
                        else sign = "Leo";
                        break;
                    }
                case 8:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Leo";
                        }
                        else sign = "Virgo";
                        break;
                    }
                case 9:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Virgo";
                        }
                        else sign = "Libra";
                        break;
                    }
                case 10:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Libra";
                        }
                        else sign = "Scorpio";
                        break;
                    }
                case 11:
                    {
                        if (day >= 1 && day <= 21)
                        {
                            sign = "Scorpio";
                        }
                        else sign = "Sagittarius";
                        break;
                    }
                case 12:
                    {
                        if (day >= 1 && day <= 21)
                        {
                            sign = "Sagittarius";
                        }
                        else sign = "Capricorn";
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
            return sign;
        }

        private string DeterminateChineaseSign()
        {
            int year = Math.Abs(2008 - _dateOfBirth.Year) % 12;
            string sign = "";
            switch (year)
            {
                case 0:
                    {
                        sign = "Rat";
                        break;
                    }
                case 1:
                    {
                        sign = "Ox";
                        break;
                    }
                case 2:
                    {
                        sign = "Tiger";
                        break;
                    }
                case 3:
                    {
                        sign = "Rabbit";
                        break;
                    }
                case 4:
                    {
                        sign = "Dragon";
                        break;
                    }
                case 5:
                    {
                        sign = "Snake";
                        break;
                    }
                case 6:
                    {
                        sign = "Horse";
                        break;
                    }
                case 7:
                    {
                        sign = "Goat";
                        break;
                    }
                case 8:
                    {
                        sign = "Monkey";
                        break;
                    }
                case 9:
                    {
                        sign = "Rooster";
                        break;
                    }
                case 10:
                    {
                        sign = "Dog";
                        break;
                    }
                case 11:
                    {
                        sign = "Pig";
                        break;
                    }
                default: throw new InvalidOperationException();
            }
            return sign;
        }


    }
}
