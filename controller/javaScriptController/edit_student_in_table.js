//  lấy thông tin của các đối tượng trong bảng truyền vào input thêm mới
function edit_Student_In_Table(editButton) {

    // lấy  đối tượng Student dựa trên value của button trùng với mã code 
    var student_temp = manager.get_Student_By_Code(editButton.value)[0];
   
    // set các thuộc tính của đối tượng student trên input thêm mới
    setInputNameStudent(student_temp.get_Name());
    setInputCodeStudent(student_temp.get_Code());
    setInputFacultyStudent(student_temp.get_Key_Faculty());
    (student_temp.get_Gender() == "Nam" ) ? setInputGenderStudent(0) : setInputGenderStudent(1) ;

    // xử lý lại "string-date" sao cho đúng định dạng "MM-DD-YYYY"
    var date_student =  student_temp.get_Date();
    var temp = String(date_student).split('/');
    date_student = temp[2]+"-"+temp[1]+"-"+temp[0];
    setInputDateStudent(date_student);
}
