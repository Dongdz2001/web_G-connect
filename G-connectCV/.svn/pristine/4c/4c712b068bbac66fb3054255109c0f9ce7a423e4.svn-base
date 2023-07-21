import { GC_CONG_VIECService } from "modules/GC_CONG_VIEC/GC_CONG_VIECService";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { Dropdown } from "primereact/dropdown";
import { InputText } from "primereact/inputtext";
import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { useParams } from "react-router-dom";
import { Link } from "react-router-dom";

export default function Cong_viec_Form(props) {
  let { id } = useParams();
  let itemId = props.id ?? id;
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const itemService = GC_CONG_VIECService;
  const defaultValues = {};
  const [listRef_id_chuc_nang, setListRef_id_chuc_nang] = useState([]);
  const [listRef_id_cong_viec_cha, setListRef_id_cong_viec_cha] = useState([]);
  const close = async () => {
    if (props.fnClose) props.fnClose();
  };
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
  const getListRef_id_chuc_nang = () => {
    return GC_CONG_VIECService.getAllRef_id_chuc_nang().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_chuc_nang(res.data);
    });
  };
  const getListRef_id_cong_viec_cha = () => {
    return GC_CONG_VIECService.getAllRef_id_cong_viec_cha().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_cong_viec_cha(res.data);
    });
  };
  useEffect(() => {
    if (itemId !== "new") getById(itemId);

    getListRef_id_chuc_nang();
    getListRef_id_cong_viec_cha();
  }, [window.location.href]);
  return (
    <div>
      <Card title={(itemId === "new" ? "Thêm" : "Sửa") + " Công việc"}>
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
                <label htmlFor="id_chuc_nang">{"Chức năng"}</label>
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
            {/* <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="id_cong_viec_cha">{"Công việc cha"}</label>
                <Controller
                  name="id_cong_viec_cha"
                  control={control}
                  rules={
                    {
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }
                  }
                  render={({ field, fieldState }) => (
                    <Dropdown
                      options={listRef_id_cong_viec_cha}
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
                {getFormErrorMessage("id_cong_viec_cha", errors)}
              </div>
            </div> */}
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="ma_cong_viec">
                  {"Mã công việc"} <span className="p-error">(*)</span>
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
                <label htmlFor="ten_cong_viec">
                  {"Tên công việc"} <span className="p-error">(*)</span>
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
            {/* <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="is_cong_viec_nhom">{"Là công việc nhóm"}</label>
                <Controller
                  name="is_cong_viec_nhom"
                  control={control}
                  rules={
                    {
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }
                  }
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
                {getFormErrorMessage("is_cong_viec_nhom", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="is_da_code">{"Đã code"}</label>
                <Controller
                  name="is_da_code"
                  control={control}
                  rules={
                    {
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }
                  }
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
                {getFormErrorMessage("is_da_code", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="is_da_test">{"Đã test"}</label>
                <Controller
                  name="is_da_test"
                  control={control}
                  rules={
                    {
                      //validate: value => value === 'pwd' || "The passwords do not match",
                      //pattern: {
                      //  value: /^[a-zA-Z]+$/,
                      //  message: 'pattern'
                      //},
                    }
                  }
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
                {getFormErrorMessage("is_da_test", errors)}
              </div>
            </div> */}
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="noi_dung">{"Nội dung"}</label>
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
                <label htmlFor="tham_khao">{"Tham khảo"}</label>
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
            <div className="col-12">
              <div className="col-sm-12">
                <label htmlFor="so_ngay_estimate">{"Số ngày dự kiến"}</label>
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
