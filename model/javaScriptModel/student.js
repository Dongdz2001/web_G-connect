class Student {
  constructor(code, name, date, gender, faculty) {
    this.name = name;

    this.code = code;

    this.gender = gender;

    this.faculty = faculty;

    this.date = date;
  }

  // các hàm thiết lập lập giá trị thuộc tính cho đối tượng Student
  set_Name(name) {
    this.name = name;
  }

  set_Code(code) {
    this.code = code;
  }

  set_Gender(gender) {
    this.gender = gender;
  }

  set_Date(date) {
    this.date = date;
  }

  set_Faculty(faculty) {
    this.faculty = faculty;
  }

  // Các hàm trả về giá trị của thuộc tính cho Student
  get_Name() {
    return this.name;
  }

  get_Code() {
    return this.code;
  }

  get_Date() {
    return this.date;
  }

  get_Gender() {
    return this.gender;
  }

  get_Faculty() {
    return this.faculty;
  }

  // lấy ra key của các ngành học trong "select-tag"
  get_Key_Faculty() {
    switch (this.faculty) {
      case "Công nghệ thông tin":
        return "cntt";
        break;
      case "Khoa học máy tính":
        return "khmt";
        break;
      case "Cơ điện tử":
        return "cdt";
        break;
      case "Tin học y sinh":
        return "thys";
        break;
    }
  }

  // Hàm in ra thông tin tổng quát tất cả thuộc tính của đối tượng student
  getDetailsInformation() {
    console.log(
      `Name: ${this.name}, Code: ${this.code}, Gender: ${this.gender}, Date: ${this.date}, Faculty: ${this.faculty} `
    );
  }
}
