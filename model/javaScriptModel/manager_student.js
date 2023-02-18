class Manager_Student {

    listStudent;
  
    constructor() {
        this.listStudent  = [];
    }

    // lấy ra giá trị của mảng list[Student]
    get_list_Student(){
      return this.listStudent;
    }

    // lấy ra giá trị độ dài của mảng 
    get_length_list_Student(){
      return this.listStudent.length;
    }


    // thêm dữ liệu vào bảng bằng cách thêm 1 mảng các phần tử chứa dữ liệu ["code","name","gender","date","faculty"]
    add_list_Manager_Student(students){
      students.forEach(element => {
        this.listStudent.push(new Student(element[0],element[1],element[2],element[3],element[4]));
      });
    }
    

    // thêm sinh viên vào mảng Student
    add_Student(student){
        this.listStudent.push(student)
    }

    // lấy ra giá trị của mảng theo mã "code"
    get_Student_By_Code(code){
      return  this.listStudent.filter(obj => {
            return obj.get_Code() === code;
          }) ?? "none";
    }

    // thay đổi thông tin của sinh viên tìm theo mã sinh viên
    set_Student_Value_By_Code(code,student_Object){
      for (let i = 0; i < this.listStudent.length; i++) {
        if (this.listStudent[i].get_Code() === code) {
          this.listStudent[i] = student_Object;
          break;
        }
      }
    }

    // Xóa phần tử mảng Student theo mã "code" 
    delete_Student_By_Code(code){
      let index = -1;
          for (let i = 0; i < this.listStudent.length; i++) {
            if (this.listStudent[i].get_Code() === code) {
              index = i;
              break;
            }
          }
        // console.log(i);
        if (index > -1) { // only splice this.listStudent when item is found
            this.listStudent.splice(index, 1); // 2nd parameter means remove one item only
            }
    }

    // Kiểm tra mã sinh viên có tồn tại trong mảng hay không
    check_code_student_exist(code) {
      var check = false;
      this.listStudent.forEach(element => {
        console.log(`${element.get_Code()} -- ${code}`);
        if (element.get_Code() == code) {
          check = true;
          return check;
        }
      });
      return check ;
    }

  
  }
  

 