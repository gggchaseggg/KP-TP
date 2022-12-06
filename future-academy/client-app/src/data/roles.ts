const toRUroles = (role:string):string => {
  switch (role) {
    case "admin":
      return "Админ"
    case "student":
      return "Студент"
    case "teacher":
      return "Преподаватель"
    default:
      return "Не указано"
  }
}

export default toRUroles;