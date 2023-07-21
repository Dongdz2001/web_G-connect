import React, { useEffect, useState, useRef } from "react";
import { useForm, Controller } from "react-hook-form";
import { InputText } from "primereact/inputtext";
import { InputTextarea } from "primereact/inputtextarea";
import { Button } from "primereact/button";
import CkEditor from "components/ckeditor4/CkEditor";
import {
  postStatusText,
  statusText,
  ACTIVE,
  DEACTIVE,
} from "shared/utils/appState";
import { SelectImgItem } from "components/SelectImgItem";
import { Checkbox } from "primereact/checkbox";
import { SelectButton } from "primereact/selectbutton";
import { AutoComplete } from "primereact/autocomplete";
import { Calendar } from "components/Calendar";
import { Dialog } from "primereact/dialog";
import { classNames } from "primereact/utils";
import { Card } from "primereact/card";
import { useParams } from "react-router-dom";
import { InputSwitch } from "primereact/inputswitch";
import { Dropdown } from "primereact/dropdown";

import { useNavigate } from "react-router-dom";
import { useTranslation } from "react-i18next";
import { decodeUnicode } from "shared/utils/decodeHtmlEntites"; 
import getFormErrorMessage from "shared/components/getFormErrorMessage";
import sessionStorage from "redux-persist/es/storage/session";

import { GC_LICH_HANG_NGAYService } from "modules/GC_LICH_HANG_NGAY/GC_LICH_HANG_NGAYService";

const EditSheetTable = (props) => {
  const [startDate, setStartDate] = useState(new Date());
  const [endDate, setEndDate] = useState(new Date());
  const { t, i18n } = useTranslation();
  let { id } = useParams();
  let itemId = props.id ?? id;
  const linkList = "/TableTimeSheet";
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const itemService = GC_LICH_HANG_NGAYService;
  const dialogFooter = (
    <div className="flex justify-content-center">
      <Button
        label="OK"
        className="p-button-text"
        autoFocus
        onClick={() => setShowMessage(false)}
      />
    </div>
  );
  /* */
  let navigate = useNavigate();
  const defaultValues = {};
  const [formData, setFormData] = useState({
    myMap: new Map(),
  });

// thêm sửa xóa các giá trị trong Map()
// Thêm một cặp key-value mới vào Map
function addKeyValuePair(key, value) {
    const newMap = new Map(formData.myMap);
    newMap.set(key, value);
    setFormData({ ...formData, myMap: newMap });
  }

// Lấy giá trị của một key từ Map
function getValueByKey(key) {
    return formData.myMap.get(key);
  }

  // Xóa một cặp key-value từ Map
  function deleteKeyValuePair(key) {
    const newMap = new Map(formData.myMap);
    newMap.delete(key);
    setFormData({ ...formData, myMap: newMap });
  }

  // Xóa tất cả các cặp key-value từ Map
  function clearMap() {
    setFormData({ ...formData, myMap: new Map() });
  }

  // Cập nhật giá trị của một key trong Map
    function updateValueByKey(key, value) {
    const newMap = new Map(formData.myMap);
    if (newMap.has(key)) {
      newMap.set(key, value);
      setFormData({ ...formData, myMap: newMap });
    } else {
        addKeyValuePair(key,value);
    }
  }
  

  const [showMessage, setShowMessage] = useState(false);

  const [listRef_id_nguoi_thuc_hien, setListRef_id_nguoi_thuc_hien] = useState(
    []
  );
  const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
  const {
    register,
    control,
    formState: { errors },
    handleSubmit,
    reset,
    watch,
    getValues,
    setValue,
  } = useForm({ defaultValues });
  const getFormErrorMessage = (name) => {
    return (
      errors[name] && <small className="p-error">{errors[name].message}</small>
    );
  };
  const onSubmit = async (formData) => {
    if (itemId === "new") {
      //console.log(formData);
      await itemService.create(formData);
    } else {
      console.log(formData);
      await itemService.update(itemId, formData);
    }
    if (props.fnLoadData) props.fnLoadData();
    if (props.fnClose) props.fnClose();
    else navigate(linkList);
  };
  const getById = async (itemId) => {
    let result = await itemService.getById(itemId);
    reset(result.data);
  };
  useEffect(() => {
    if (itemId !== "new") getById(itemId);
    getListRef_id_nguoi_thuc_hien();
    getListRef_id_cong_viec();
  }, [window.location.href]);

  const getListRef_id_nguoi_thuc_hien = () => {
    return GC_LICH_HANG_NGAYService.getAllRef_id_nguoi_thuc_hien().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_nguoi_thuc_hien(res.data);
      }
    );
  };
  const getListRef_id_cong_viec = () => {
    return GC_LICH_HANG_NGAYService.getAllRef_id_cong_viec().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_cong_viec(res.data);
    });
  };
  const close = async () => {
    if (props.fnClose) props.fnClose();
    else navigate(linkList);
    //navigate(-1);
  };
  return (
    <div style={{ width: "800px" }}>
      <Dialog
        visible={showMessage}
        onHide={() => setShowMessage(false)}
        position="top"
        footer={dialogFooter}
        showHeader={false}
        breakpoints={{ "960px": "80vw" }}
        style={{ width: "30vw" }}
      >
        <div className="flex justify-content-center flex-column pt-6 px-3"></div>
      </Dialog>

      <Card title={(itemId === "new" ? "Thêm" : "Sửa") + " Timesheet"}>
        <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
          <div className="row">
            <br />
            <br />
        
            <Controller
              name="xxx"
              control={control}
              render={({ field, fieldState }) => (
                <InputText {...field} className={"hide"} value={field.value} />
              )}
            />

            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="id_nguoi_thuc_hien">{"Nhân viên:"}</label>
                <p
                  name="id_nguoi_thuc_hien"
                  style={{ marginLeft: "10px", display: "inline-block" }}
                >
                  {watch("ten_id_nguoi_thuc_hien")}
                </p>
                {getFormErrorMessage("id_nguoi_thuc_hien", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <div style={{ width: "600px", display: "flex" }}>
                  <label
                    htmlFor="id_cong_viec"
                    style={{ display: "inline-block" }}
                  >
                    {"Công việc:"}
                  </label>
                  <p
                    name="id_cong_viec"
                    style={{ marginLeft: "10px", display: "inline-block" }}
                  >
                    {watch("ten_id_cong_viec")}
                  </p>
                </div>
                {getFormErrorMessage("id_cong_viec", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="ngay_lam_viec">{"Ngày làm"}</label>
                <Controller
                  name="ngay_lam_viec"
                  control={control}
                  render={({ field, fieldState }) => (
                    <Calendar
                      className=""
                      showButtonBar={true}
                      dateFormat="dd/mm/yy"
                      id="ngay_lam_viec"
                      defaultValue="01/01/2001"
                      {...field}
                      value={field.value ?? new Date()} // Gán giá trị mặc định là ngày hiện tại nếu trường không có giá trị
                      mask="99/99/9999"
                      showIcon
                      placeholder="Ngày làm"
                      minDate={
                        new Date(new Date().setMonth(new Date().getMonth() - 1))
                      } // cách 1 tháng
                      maxDate={new Date()} // ngày hiện tại
                    />
                  )}
                />
                {getFormErrorMessage("ngay_lam_viec", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="so_gio">{"Số giờ"}</label>
                <Controller
                  name="so_gio"
                  control={control}
                  rules={{}}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("so_gio", errors)}
              </div>
            </div>
            <div>
              <Calendar
                value={startDate}
                onChange={(e) => setStartDate(e.value)}
                showButtonBar
              />
              <Calendar
                value={endDate}
                onChange={(e) => setEndDate(e.value)}
                showButtonBar
              />
            </div>

            <div className={props.fnClose ? "text-center" : "col-12"}>
              <Button
                label={labelSave}
                icon="fa fa-save"
                style={{ width: "100px" }}
              />
              <Button
                className="btnClose"
                style={{ width: 100 }}
                onClick={close.bind(this)}
                label={labelClose}
              ></Button>
            </div>
          </div>
        </form>
      </Card>
    </div>
  );
};
export default EditSheetTable;

   {/* <div className={props.fnClose ? 'text-center' : 'col-12'}>
                            <Button label={labelSave} icon='fa fa-save' style={{ width: '100px' }} />
                            <Button className="btnClose" style={{width:100}} onClick={close.bind(this)} label={labelClose}></Button>
                        </div> */}

// rules={
//     {
//       //validate: value => value === 'pwd' || "The passwords do not match",
//       //pattern: {
//       //  value: /^[a-zA-Z]+$/,
//       //  message: 'pattern'
//       //},
//     }
//   }

    // console.log(formData);
    // if (startDate && endDate) {
    //   // Lấy giá trị ngày bắt đầu và ngày kết thúc từ state
    //   const start = startDate;
    //   const end = endDate;

    //   // Tính số ngày giữa 2 ngày bằng cách chuyển về đơn vị giây và chia cho 1 ngày (86400 giây)
    //   const days = Math.ceil((end - start) / 86400 / 1000);

    //   // Tạo một mảng các giá trị số giờ cho từng ngày
    //   const hoursPerDay = [];
    //   for (let i = 0; i < days; i++) {
    //     const day = new Date(
    //       start.getTime() + i * 86400 * 1000
    //     ).toLocaleDateString("en-US", { timeZone: "UTC" }); // Chuyển đổi sang định dạng mm/dd/yyyy
    //     hoursPerDay.push({ ngay: day, so_gio: formData.so_gio });
    //   }

    //   // Thực hiện lưu dữ liệu bằng cách sử dụng hoursPerDay thay vì formData
    //   if (itemId === "new") {
    //     await itemService.create(hoursPerDay);
    //   } else {
    //     await itemService.update(itemId, hoursPerDay);
    //   }
    // }