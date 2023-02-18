class Manager_Student {
  listStudent;

  constructor() {
    this.listStudent = [];
  }

  // <-----------------    get-data      ---------------------------------------------->

  // lấy ra giá trị của mảng list[Student]
  get_list_Student() {
    return this.listStudent;
  }

  // lấy ra giá trị độ dài của mảng
  get_length_list_Student() {
    return this.listStudent.length;
  }

  // lấy ra giá trị của mảng theo mã "code"
  get_Student_By_Code(code) {
    return (
      this.listStudent.filter((obj) => {
        return obj.get_Code() === code;
      }) ?? "none"
    );
  }

  // lấy ra giá trị của mảng theo mã "name"
  get_Student_By_Name(name) {
    return (
      this.listStudent.filter((obj) => {
        return obj.get_Name() === name;
      }) ?? "none"
    );
  }

  // lấy ra giá trị của mảng theo mã "date"
  get_Student_By_Date(date) {
    return (
      this.listStudent.filter((obj) => {
        return obj.get_Date() === date;
      }) ?? "none"
    );
  }

  // < --------------------  add-data ---------------------------->

  // thêm dữ liệu vào bảng bằng cách thêm 1 mảng các phần tử chứa dữ liệu ["code","name","gender","date","faculty"]
  add_list_Manager_Student(students) {
    students.forEach((element) => {
      this.listStudent.push(
        new Student(element[0], element[1], element[2], element[3], element[4])
      );
    });
  }

  // thêm sinh viên vào mảng Student
  add_Student(student) {
    this.listStudent.push(student);
  }

  // <-----------------------------  set-data  --------------------------------->

  // thay đổi thông tin của sinh viên tìm theo mã sinh viên
  set_Student_Value_By_Code(code, student_Object) {
    for (let i = 0; i < this.listStudent.length; i++) {
      if (this.listStudent[i].get_Code() === code) {
        this.listStudent[i] = student_Object;
        break;
      }
    }
  }

  // <----------------------  custom-data  ------------------------------------------->
  // Xóa phần tử mảng Student theo mã "code"
  delete_Student_By_Code(code) {
    let index = -1;
    for (let i = 0; i < this.listStudent.length; i++) {
      if (this.listStudent[i].get_Code() === code) {
        index = i;
        break;
      }
    }
    // console.log(i);
    if (index > -1) {
      // only splice this.listStudent when item is found
      this.listStudent.splice(index, 1); // 2nd parameter means remove one item only
    }
  }

  // Kiểm tra mã sinh viên có tồn tại trong mảng hay không
  check_code_student_exist(code) {
    var check = false;
    this.listStudent.forEach((element) => {
      if (element.get_Code() == code) {
        check = true;
        return check;
      }
    });
    return check;
  }

  // <----------------------------- Search-data ----------------------------->

  // tìm kiếm các đối tương student có chứa name_input trong tên
  search_student_by_name(name_input,listStudent) {
    var result_students = [];
    listStudent.filter((obj) => {
      if (obj.get_Name().toUpperCase().includes(name_input.toUpperCase())) {
        result_students.push(obj);
      }
    });
    return result_students;
  }

  // tìm kiếm student theo giới tính
  search_student_by_gender(name_input,listStudent) {
    var result_students = [];
    listStudent.filter((obj) => {
      if (obj.get_Gender().toUpperCase().includes(name_input.substring(1,).toUpperCase())) {
        result_students.push(obj);
      }
    });
    return result_students;
  }

  // tìm kiếm student theo khoa
  search_student_by_faculty(name_input,listStudent) {
    var result_students = [];
    listStudent.filter((obj) => {
      if (
        obj
          .get_Key_Faculty()
          .toUpperCase()
          .includes(name_input.toUpperCase()) ||
        obj.get_Faculty().toUpperCase().includes(name_input.toUpperCase())
      ) {
        result_students.push(obj);
      }
    });
    return result_students;
  }

  // tìm kiếm student theo mã sinh viên
  search_student_by_code(name_input,listStudent) {
    var result_students = [];
    listStudent.filter((obj) => {
      if (obj.get_Code().toUpperCase().includes(name_input.toUpperCase())) {
        result_students.push(obj);
      }
    });
    return result_students;
  }

  // tìm kiếm student theo ngày tháng năm sinh của sinh viên
  search_student_by_date(name_input,listStudent) {
    // xử lý đầu vào và khai báo mảng lưu trữ
    name_input = name_input.replaceAll(" ", "");
    var result_students = [];

   
    // Kiểm tra xem ký tự ngăn cách của input nhập vào là ký tự nào
    var temp_char = "";
    char.forEach((element) => {
      if (name_input.includes(element)) {
        temp_char = element;
      }
    });
    // Kiểm tra xem input nhập vào có phải là năm hay không
    if (temp_char == "") {
      listStudent.filter((obj) => {
        var date_Student = obj.get_Date().split("/");
        if (name_input == date_Student[2] && name_input.length == 4) {
          result_students.push(obj);
        } else if (
          parseInt(name_input) == parseInt(date_Student[0]) ||
          parseInt(name_input) == parseInt(date_Student[1])
        ) {
          result_students.push(obj);
        }
      });
    }

    // Kiểm tra xem input nhập vào các các thành phần DD/MM không thông qua ký tự ngăn cách
    if (temp_char != "") {
      var date_element_input = name_input.split(temp_char);
      listStudent.filter((obj) => {
        var date_Student = obj.get_Date().split("/");
        var flag_check = true;
        for (let i = 0; i < date_element_input.length; i++) {
          if (parseInt(date_Student[i]) != parseInt(date_element_input[i])) {
            flag_check = false;
          }
        }
        if (flag_check) {
          result_students.push(obj);
        }
      });
    }

    return result_students;
  }
}
