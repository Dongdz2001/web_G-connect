import { GC_LICH_TUANService } from "modules/GC_LICH_TUAN/GC_LICH_TUANService";
import { Button } from "primereact/button";
import { Card } from "primereact/card";
import { Dropdown } from "primereact/dropdown";
import { InputText } from "primereact/inputtext";
import { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { useNavigate, useParams } from "react-router-dom";
import { getCurrentUserDefault } from "shared/utils/getCurrentUserDefault";
import { Link } from "react-router-dom";

export default function CLIENT_LICH_TUANForm(props) {
  const defaultValues = {};
  const itemService = GC_LICH_TUANService;
  const labelSave = "Lưu";
  const labelClose = "Đóng";
  const linkList = "/client/lich-tuan";
  //let { id } = useParams();
  const id = getCurrentUserDefault().id;
  let itemId = props.id ?? id;
  const [listRef_id_nguoi_thuc_hien, setListRef_id_nguoi_thuc_hien] = useState(
    []
  );
  let navigate = useNavigate();

  const onSubmit = async (formData) => {
    if(formData.id_nguoi_thuc_hien) {
      await itemService.create(formData);
      if (props.fnLoadData) props.fnLoadData();
      if (props.fnClose) props.fnClose();
      else navigate(`${linkList}/${id}`);
    }
  };
  const close = async () => {
    if (props.fnClose) props.fnClose();
    else navigate(`${linkList}/${id}`);
    //navigate(-1);
  };
  const getFormErrorMessage = (name) => {
    return (
      errors[name] && <small className="p-error">{errors[name].message}</small>
    );
  };
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

  const getById = async (itemId) => {
    let result = await itemService.getById(itemId);
    reset(result.data);
  };
  useEffect(() => {
    if (itemId !== "new") getById(itemId);

    getListRef_id_nguoi_thuc_hien();
  }, [window.location.href]);
  const getListRef_id_nguoi_thuc_hien = () => {
    return GC_LICH_TUANService.getAllRef_id_nguoi_thuc_hien().then((res) => {
      res.data.map((x) => {
        x.Value = x.value;
        x.Text = x.label;
      });
      res.data = res.data.filter(x=>props.items.find(y=>y.id_nguoi_thuc_hien===x.value)==undefined);
      setListRef_id_nguoi_thuc_hien(res.data);
    });
  };
  return (
    <div>
      <Card title="Thêm lịch tuần, lịch thực tập">
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
                <h4 htmlFor="id_nguoi_thuc_hien">Nhân viên</h4>
                <Controller
                  name="id_nguoi_thuc_hien"
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
                <h4 htmlFor="so_dien_thoai">Số điện thoại</h4>
                <Controller
                  name="so_dien_thoai"
                  control={control}
                  rules={{
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
                {getFormErrorMessage("so_dien_thoai", errors)}
              </div>
            </div>
            <div className="col-12">
              <div className="col-sm-12">
                <h4 htmlFor="link_bao_cao">Link báo cáo</h4>
                <Controller
                  name="link_bao_cao"
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
                    <InputText {...field} value={field.value ?? ""} />
                  )}
                />
                {getFormErrorMessage("link_bao_cao", errors)}
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
