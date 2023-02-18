let manager = new Manager_Student();

 // Định nghĩa các ký tụ ngăn cách có thể có để kiểm tra
 var char = [
  "/",
  "*",
  "-",
  "|",
  "\\",
  "_",
  "+",
  "$",
  "%",
  "^",
  "&",
  "?",
  "=",
];

function run_main() {
  let student = new Student(
    "123123123",
    "Duong Tuan Anh",
    "Nam",
    "12/2/2001",
    "Cong nghe sinh hoc"
  );
  // studen.getDetailsInformation();
  manager.add_Student(student);
  manager.get_listStudent()[0].getDetailsInformation();
}

// test thử việc tìm kiếm student by ID
function check_student_by_ID() {
  var temp = manager.get_Student_By_Code("123123123");
  console.log(
    temp.length != 0
      ? temp[0].getDetailsInformation()
      : "not found this student!"
  );

  console.log(manager);
}





