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

import { GC_CHUC_NANGService } from "modules/GC_CHUC_NANG/GC_CHUC_NANGService";
import { FileUpload } from "primereact/fileupload";
import { Link } from "react-router-dom";

const ChucnangForm = (props) => {
  const { t, i18n } = useTranslation();
  let { id } = useParams();
  let itemId = props.id ?? id;
  const linkList = "/chucnangs/chucnang";
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const itemService = GC_CHUC_NANGService;
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
  const [formData, setFormData] = useState({});
  const [showMessage, setShowMessage] = useState(false);

  const [listRef_id_du_an, setListRef_id_du_an] = useState([]);
  const [listRef_id_linh_vuc, setListRef_id_linh_vuc] = useState([]);
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
      await itemService.update(itemId, formData);
      props.loadLazyData();
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

    getListRef_id_du_an();
    getListRef_id_linh_vuc();
  }, [window.location.href]);

  const getListRef_id_du_an = () => {
    return GC_CHUC_NANGService.getAllRef_id_du_an().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_du_an(res.data);
    });
  };
  const getListRef_id_linh_vuc = () => {
    return GC_CHUC_NANGService.getAllRef_id_linh_vuc().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      setListRef_id_linh_vuc(res.data);
    });
  };
  const close = async () => {
    if (props.fnClose) props.fnClose();
    else navigate(linkList);
    //navigate(-1);
  };
  return (
    <div>
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

      <Card title={(itemId === "new" ? "Thêm" : "Sửa") + " Chức năng"}>
        <form className="p-fluid" onSubmit={handleSubmit(onSubmit)}>
          <div className="row">

            <Controller
              name="xxx"
              control={control}
              render={({ field, fieldState }) => (
                <InputText {...field} className={"hide"} value={field.value} />
              )}
            />

            <div className="col-sm-6">
              <label htmlFor="id_du_an">{"Dự án"}</label>
              <Controller
                name="id_du_an"
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
                    options={listRef_id_du_an}
                    optionValue="Value"
                    optionLabel="Text"
                    scrollHeight={"600px"}
                    className=""
                    {...field}
                    value={field.value ?? ""}
                    placeholder="--Chọn--"
                    disabled
                    showClear
                  />
                )}
              />
              {getFormErrorMessage("id_du_an", errors)}
            </div>
            <div className="col-sm-6">
              <label htmlFor="id_linh_vuc">{"Lĩnh vực"}</label>
              <Controller
                name="id_linh_vuc"
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
                    options={listRef_id_linh_vuc}
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
              {getFormErrorMessage("id_linh_vuc", errors)}
            </div>
            <div className="col-sm-6">
              <label htmlFor="ma_chuc_nang">
                {"Mã chức năng"} <span className="p-error">(*)</span>
              </label>
              <Controller
                name="ma_chuc_nang"
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
                  //validate: value => value === 'pwd' || "The passwords do not match",
                  //pattern: {
                  //  value: /^[a-zA-Z]+$/,
                  //  message: 'pattern'
                  //},
                }}
                render={({ field, fieldState }) => (
                  <InputText {...field} value={field.value ?? ""} />
                )}
              />
              {getFormErrorMessage("ma_chuc_nang", errors)}
            </div>
            <div className="col-sm-6">
              <label htmlFor="ten_chuc_nang">
                {"Tên chức năng"} <span className="p-error">(*)</span>
              </label>
              <Controller
                name="ten_chuc_nang"
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
                  //validate: value => value === 'pwd' || "The passwords do not match",
                  //pattern: {
                  //  value: /^[a-zA-Z]+$/,
                  //  message: 'pattern'
                  //},
                }}
                render={({ field, fieldState }) => (
                  <InputText {...field} value={field.value ?? ""} />
                )}
              />
              {getFormErrorMessage("ten_chuc_nang", errors)}
            </div>
            <div className="col-sm-3">
              <label htmlFor="stt">{"Thứ  tự"}</label>
              <Controller
                name="stt"
                control={control}
                rules={{
                  maxLength: {
                    value: 11,
                    message: "Không quá 11 ký tự",
                  },
                  //validate: value => value === 'pwd' || "The passwords do not match",
                  //pattern: {
                  //  value: /^[a-zA-Z]+$/,
                  //  message: 'pattern'
                  //},
                }}
                render={({ field, fieldState }) => (
                  <InputText {...field} value={field.value ?? ""} />
                )}
              />
              {getFormErrorMessage("stt", errors)}
            </div>
            <div className="col-sm-3">
              <label htmlFor="is_cong_bo">{"Đã công bố"}</label>
              <Controller
                name="is_cong_bo"
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
              {getFormErrorMessage("is_cong_bo", errors)}
            </div>
            <div className="col-sm-3">
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
            <div className="col-sm-3">
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
            <div className="col-sm-12">
              <label htmlFor="noi_dung">{"Nội dung"}</label>
              <Controller
                name="noi_dung"
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
                  <CkEditor
                    editor="content"
                    id="content"
                    config={{ height: 300 }}
                    content={field.value}
                    events={{
                      change: (event) => {
                        field.onChange(event.editor.getData());
                      },
                    }}
                    className={classNames({
                      "p-invalid": fieldState.invalid,
                    })}
                  />
                )}
              />
              {getFormErrorMessage("noi_dung", errors)}
            </div>
            <div className="col-sm-12">
              <label htmlFor="file_dinh_kem">{"File đính kèm"}</label>
              <Controller
                name="file_dinh_kem"
                control={control}
                rules={{
                  maxLength: {
                    value: 200,
                    message: "Không quá 200 ký tự",
                  },
                  //validate: value => value === 'pwd' || "The passwords do not match",
                  //pattern: {
                  //  value: /^[a-zA-Z]+$/,
                  //  message: 'pattern'
                  //},
                }}
                render={({ field, fieldState }) => (
                  <FileUpload {...field} value={field.value ?? ""} />
                )}
              />
              {getFormErrorMessage("file_dinh_kem", errors)}
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
};
export default ChucnangForm;
