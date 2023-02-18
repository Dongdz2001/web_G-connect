// tạo 1 list danh  sách student cho table
function create_Data_Table() {
    // tạo list data cho table
    list_students = [
      [
        "123123123",
        "Duong Minh Dong",
        "12/08/2001",
        "Nam",
        "Công nghệ thông tin",
      ],
      [
        "123123124",
        "Nguyen Minh Khanh",
        "12/08/2001",
        "Nam",
        "Công nghệ thông tin",
      ],
      ["123123125", "Tran Minh Nam", "12/08/2001", "Nam", "Công nghệ thông tin"],
      ["123123126", "Hao Minh Tuan", "12/08/2001", "Nam", "Công nghệ thông tin"],
      [
        "123123127",
        "Trong Minh Thanh",
        "12/08/2001",
        "Nam",
        "Công nghệ thông tin",
      ],
      ["123123128", "Lo Minh Hao", "12/08/2001", "Nam", "Công nghệ thông tin"],
      [
        "123123129",
        "Nguyen Minh Chung",
        "12/08/2001",
        "Nam",
        "Công nghệ thông tin",
      ],
      ["123123120", "Ly Minh Hi", "12/08/2001", "Nam", "Công nghệ thông tin"],
      ["123123122", "Trinh Minh Ca", "12/08/2001", "Nam", "Công nghệ thông tin"],
      ["123123324", "Mac Minh Cong", "12/08/2001", "Nam", "Công nghệ thông tin"],
    ];
  
    // add list_students vào Manager_Students để quản lý
    manager.add_list_Manager_Student(list_students);
  
    // gọi ra table đang hiển thị thông tin
    var outputTbl = document.getElementById("table-display-student");
  
    manager.get_list_Student().forEach((element) => {
      // Thêm thẻ "tr" vào outputTbl
      var output = document.createElement(`tr`);
      outputTbl.appendChild(output);
  
      // Thêm các thông tin sinh viên thành 1 dòng mới trong bảng "table-display-student"
      output.innerHTML += '<td> <input type="checkbox" name="checkbox"> </td>';
      output.innerHTML += "<td>" + element.get_Code() + "</td>";
      output.innerHTML += "<td>" + element.get_Name() + "</td>";
      output.innerHTML += "<td>" + element.get_Date() + "</td>";
      output.innerHTML += "<td>" + element.get_Gender() + "</td>";
      output.innerHTML += "<td>" + element.get_Faculty() + "</td>";
      output.innerHTML += `<td> <div style=\"padding-top: 30px;\"> <button type=\"button\" class=\"btn btn-edit\" value=\"${element.get_Code()}\" onclick=\"delete_func(this)\">Xóa</button> <button class=\"btn btn-edit\" value=\"${element.get_Code()}\" onclick=\"edit_Student_In_Table(this)\" >Sửa</button> </div> </td>`;
    });
  }
  