import { GC_CONG_VIEC_CHECKLISTService } from "modules/GC_CONG_VIEC_CHECKLIST/GC_CONG_VIEC_CHECKLISTService";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { Dropdown } from "primereact/dropdown";
import { InputText } from "primereact/inputtext";
import React, { useEffect, useState, useRef } from "react";
import { Controller, useForm } from "react-hook-form";
import { Link } from "react-router-dom";

export default function ChecklistAdd(props) {
  const itemService = GC_CONG_VIEC_CHECKLISTService;
  const defaultValues = {};
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
  const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
  const [listRef_id_loai_checklist, setListRef_id_loai_checklist] = useState(
    []
  );
  const {
    control,
    formState: { errors },
    handleSubmit,
  } = useForm({ defaultValues });
  const onSubmit = async (formData) => {
    await itemService.create(formData);
    props.loadLazyData();
    if (props.fnClose) props.fnClose();
  };
  const getFormErrorMessage = (name) => {
    return (
      errors[name] && <small className="p-error">{errors[name].message}</small>
    );
  };
  const close = async () => {
    if (props.fnClose) props.fnClose();
  };
  const getListRef_id_chuc_nang = () => {
    return GC_CONG_VIEC_CHECKLISTService.getAllRef_id_chuc_nang().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_chuc_nang(res.data);
      }
    );
  };
  const getListRef_id_cong_viec = () => {
    return GC_CONG_VIEC_CHECKLISTService.getAllRef_id_cong_viec().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_cong_viec(res.data);
      }
    );
  };
  const getListRef_id_loai_checklist = () => {
    return GC_CONG_VIEC_CHECKLISTService.getAllRef_id_loai_checklist().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_loai_checklist(res.data);
      }
    );
  };
  useEffect(() => {
    getListRef_id_chuc_nang();
    getListRef_id_cong_viec();
    getListRef_id_loai_checklist();
  }, [window.location.href]);
  return (
    <div>
      <Card title={"Thêm Title of GC_CONG_VIEC_CHECKLIST"}>
        <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
          <div className="row">

            <Controller
              name="xxx"
              control={control}
              render={({ field, fieldState }) => (
                <InputText {...field} className={"hide"} value={field.value} />
              )}
            />
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="stt">{"Thứ  tự"}</label>
                <Controller
                  name="stt"
                  control={control}
                  rules={{
                    maxLength: {
                      value: 11,
                      message: "Không quá 11 ký tự",
                    },
                  }}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("stt", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="id_chuc_nang">{"Menu"}</label>
                <Controller
                  name="id_chuc_nang"
                  control={control}
                  render={({ field, fieldState }) => (
                    <Dropdown
                      options={listRef_id_chuc_nang}
                      optionValue="Value"
                      optionLabel="Text"
                      scrollHeight={"600px"}
                      className=""
                      {...field}
                      value={field.value ?? ""}
                      placeholder="--Chọn--"
                      showClear
                    />
                  )}
                />
                {getFormErrorMessage("id_chuc_nang", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="ma_cong_viec">
                  {"Mã CN"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="ma_cong_viec"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    maxLength: {
                      value: 20,
                      message: "Không quá 20 ký tự",
                    },
                  }}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("ma_cong_viec", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="id_cong_viec">{"Tên chức năng"}</label>
                <Controller
                  name="id_cong_viec"
                  control={control}
                  render={({ field, fieldState }) => (
                    <Dropdown
                      options={listRef_id_cong_viec}
                      optionValue="Value"
                      optionLabel="Text"
                      scrollHeight={"600px"}
                      className=""
                      {...field}
                      value={field.value ?? ""}
                      placeholder="--Chọn--"
                      showClear
                    />
                  )}
                />
                {getFormErrorMessage("id_cong_viec", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="id_loai_checklist">{"Loại checklist"}</label>
                <Controller
                  name="id_loai_checklist"
                  control={control}
                  render={({ field, fieldState }) => (
                    <Dropdown
                      options={listRef_id_loai_checklist}
                      optionValue="Value"
                      optionLabel="Text"
                      scrollHeight={"600px"}
                      className=""
                      {...field}
                      value={field.value ?? ""}
                      placeholder="--Chọn--"
                      showClear
                    />
                  )}
                />
                {getFormErrorMessage("id_loai_checklist", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="ten_cong_viec">
                  {"Checklist"} <span className="p-error">(*)</span>
                </label>
                <Controller
                  name="ten_cong_viec"
                  control={control}
                  rules={{
                    required: {
                      value: true,
                      message: "Vui lòng nhập!",
                    },
                    maxLength: {
                      value: 200,
                      message: "Không quá 200 ký tự",
                    },
                  }}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("ten_cong_viec", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="ket_qua_mong_muon">{"Kết quả mong muốn"}</label>
                <Controller
                  name="ket_qua_mong_muon"
                  control={control}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("ket_qua_mong_muon", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="ghi_chu_khac">{"Ghi chú khác"}</label>
                <Controller
                  name="ghi_chu_khac"
                  control={control}
                  render={({ field, fieldState }) => (
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("ghi_chu_khac", errors)}
              </div>
            </div>

            <div className={props.fnClose ? "text-center" : "col-12"}>
              <Button
                label={labelSave}
                icon="fa fa-save"
                style={{ width: "100px" }}
              />
              <Link to={null} onClick={close.bind(this)}>
                  <Button className="btnClose"style={{ width: 100 }} label={labelClose} />
              </Link>
            </div>
          </div>
        </form>
      </Card>
    </div>
  );
}
