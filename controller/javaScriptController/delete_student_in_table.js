// Xoá tất cả các dòng trong table
function delete_all_row_in_student_table() {
    var tableHeaderRowCount = 1;
    var table = document.getElementById("table-display-student");
    var rowCount = table.rows.length;
    for (var i = tableHeaderRowCount; i < rowCount; i++) {
      table.deleteRow(tableHeaderRowCount);
    }
  }

    // xóa sinh viên trong bảng theo một vị trí xác định
    function delete_func(deleteButton) {
        manager.delete_Student_By_Code(deleteButton.value);
        render_table_student();
      }