import { Calendar } from "components/Calendar";
import { GC_CONG_VIEC_PHAN_CONGService } from "modules/GC_CONG_VIEC_PHAN_CONG/GC_CONG_VIEC_PHAN_CONGService";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { Dropdown } from "primereact/dropdown";
import { InputSwitch } from "primereact/inputswitch";
import { InputText } from "primereact/inputtext";
import React, { useState, useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { useParams } from "react-router-dom";
import {
  postStatusText,
  statusText,
  ACTIVE,
  DEACTIVE,
} from "shared/utils/appState";
import { Link } from "react-router-dom";

export default function Cong_Viec_Phan_Cong_Form(props) {
  let { id } = useParams();
  let itemId = props.id ?? id;
  const defaultValues = {};
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const itemService = GC_CONG_VIEC_PHAN_CONGService;
  const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
  const [listRef_id_cong_viec, setListRef_id_cong_viec] = useState([]);
  // const [listRef_id_trang_thai, setListRef_id_trang_thai] = useState([]);
  const [listRef_id_nguoi_thuc_hien, setListRef_id_nguoi_thuc_hien] = useState(
    []
  );
  // const [listRef_id_nguoi_phoi_hop, setListRef_id_nguoi_phoi_hop] = useState(
  //   []
  // );
  // const [listRef_id_nguoi_duyet, setListRef_id_nguoi_duyet] = useState([]);
  const {
    control,
    formState: { errors },
    handleSubmit,
    reset,
  } = useForm({ defaultValues });
  const getFormErrorMessage = (name) => {
    return (
      errors[name] && <small className="p-error">{errors[name].message}</small>
    );
  };
  const onSubmit = async (formData) => {
    if (itemId === "new") {
      await itemService.create(formData);
    } else {
      await itemService.update(itemId, formData);
      props.loadLazyData()
    }
    if (props.fnClose) props.fnClose();
  };
  const getById = async (itemId) => {
    let result = await itemService.getById(itemId);
    reset(result.data);
  };
  const close = async () => {
    if (props.fnClose) props.fnClose();
  };
  useEffect(() => {
    if (itemId !== "new") getById(itemId);

    getListRef_id_chuc_nang();
    getListRef_id_cong_viec();
    getListRef_id_nguoi_thuc_hien();
  }, [window.location.href]);

  const getListRef_id_chuc_nang = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_chuc_nang().then(
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
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_cong_viec().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_cong_viec(res.data);
      }
    );
  };
  const getListRef_id_nguoi_thuc_hien = () => {
    return GC_CONG_VIEC_PHAN_CONGService.getAllRef_id_nguoi_thuc_hien().then(
      (res) => {
        res.data.map((x) => {
          x.Value = x.value;
          x.Text = x.label;
        });
        setListRef_id_nguoi_thuc_hien(res.data);
      }
    );
  };
  return (
    <div>
      <Card
        title={
          (itemId === "new" ? "Thêm" : "Sửa") +
          " Phân công Công việc"
        }
      >
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
                <label htmlFor="noi_dung">{"Tác nhân"}</label>
                <Controller
                  name="noi_dung"
                  control={control}
                  render={({ field, fieldState }) => (
                    // <CkEditor
                    //   editor="content"
                    //   id="content"
                    //   config={{ height: 300 }}
                    //   content={field.value}
                    //   events={{
                    //     change: (event) => {
                    //       field.onChange(event.editor.getData());
                    //     },
                    //   }}
                    //   className={classNames({
                    //     "p-invalid": fieldState.invalid,
                    //   })}
                    // />
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("noi_dung", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="ten_cong_viec">
                  {"Mô tả"} <span className="p-error">(*)</span>
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
                <label htmlFor="tra_loi">{"Sẵn sàng cho Dev"}</label>
                <Controller
                  name="tra_loi"
                  control={control}
                  render={({ field, fieldState }) => (
                    // <CkEditor
                    //   editor="content"
                    //   id="content"
                    //   config={{ height: 300 }}
                    //   content={field.value}
                    //   events={{
                    //     change: (event) => {
                    //       field.onChange(event.editor.getData());
                    //     },
                    //   }}
                    //   className={classNames({
                    //     "p-invalid": fieldState.invalid,
                    //   })}
                    // />
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("tra_loi", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="id_nguoi_thuc_hien">{"Phân công"}</label>
                <Controller
                  name="id_nguoi_thuc_hien"
                  control={control}
                  render={({ field, fieldState }) => (
                    <Dropdown
                      options={listRef_id_nguoi_thuc_hien}
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
                {getFormErrorMessage("id_nguoi_thuc_hien", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="dac_ta">{"Đặc tả"}</label>
                <Controller
                  name="dac_ta"
                  control={control}
                  render={({ field, fieldState }) => (
                    // <CkEditor
                    //   editor="content"
                    //   id="content"
                    //   config={{ height: 300 }}
                    //   content={field.value}
                    //   events={{
                    //     change: (event) => {
                    //       field.onChange(event.editor.getData());
                    //     },
                    //   }}
                    //   className={classNames({
                    //     "p-invalid": fieldState.invalid,
                    //   })}
                    // />
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("dac_ta", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="so_ngay_estimate">{"Estimate giờ công"}</label>
                <Controller
                  name="so_ngay_estimate"
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
                {getFormErrorMessage("so_ngay_estimate", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-2">
                <label htmlFor="ngay_ket_thuc">{"Ngày kết thúc"}</label>
                <Controller
                  name="ngay_ket_thuc"
                  control={control}
                  render={({ field, fieldState }) => (
                    <Calendar
                      style={{ width:'100vw'}}
                      showButtonBar={true}
                      dateFormat="dd/mm/yy"
                      id="ngay_ket_thuc"
                      {...field}
                      value={field.value ?? ""}
                      mask="99/99/9999"
                      showIcon
                      placeholder="Ngày kết thúc"
                    />
                  )}
                />
                {getFormErrorMessage("ngay_ket_thuc", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="is_da_duyet">{"Status"}</label>
                <Controller
                  name="is_da_duyet"
                  control={control}
                  render={({ field, fieldState }) => (
                    <InputSwitch
                      trueValue={ACTIVE}
                      falseValue={DEACTIVE}
                      tooltip={
                        field.value == ACTIVE
                          ? statusText.active
                          : statusText.deactive
                      }
                      checked={field.value}
                      onChange={(e) => field.onChange(e.target.value)}
                    />
                  )}
                />
                {getFormErrorMessage("is_da_duyet", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="log_review">{"Estimate API"}</label>
                <Controller
                  name="log_review"
                  control={control}
                  render={({ field, fieldState }) => (
                    // <CkEditor
                    //   editor="content"
                    //   id="content"
                    //   config={{ height: 300 }}
                    //   content={field.value}
                    //   events={{
                    //     change: (event) => {
                    //       field.onChange(event.editor.getData());
                    //     },
                    //   }}
                    //   className={classNames({
                    //     "p-invalid": fieldState.invalid,
                    //   })}
                    // />
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("log_review", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="tham_khao">{"Ghi chú Coding"}</label>
                <Controller
                  name="tham_khao"
                  control={control}
                  render={({ field, fieldState }) => (
                    // <CkEditor
                    //   editor="content"
                    //   id="content"
                    //   config={{ height: 300 }}
                    //   content={field.value}
                    //   events={{
                    //     change: (event) => {
                    //       field.onChange(event.editor.getData());
                    //     },
                    //   }}
                    //   className={classNames({
                    //     "p-invalid": fieldState.invalid,
                    //   })}
                    // />
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("tham_khao", errors)}
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
