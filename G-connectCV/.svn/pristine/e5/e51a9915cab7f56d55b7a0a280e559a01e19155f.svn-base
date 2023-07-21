import { loadable } from "../shared/utils";

const clientRouters = [
  {
    path: "/lich-tuan",
    component: loadable(() =>
      import("../modules/CLIENT_LICH_TUAN/CLIENT_LICH_TUANList")
    ),
  },
  {
    path: "/lich-tuan-form/:id",
    component: loadable(() =>
      import("../modules/CLIENT_LICH_TUAN/CLIENT_LICH_TUANForm")
    ),
  },
  {
    path: "/du-an",
    component: loadable(() =>
      import("../modules/client_DU_AN/DuanList")
    ),
  },
  {
    path: "/van-de",
    component: loadable(() =>
      import("../modules/client_issue/IssueList")
    ),
  },
  {
    path: "/time-sheet",
    component: loadable(() =>
      import("../modules/client_timesheet/TableTimeSheet")
    ),
  },
  {
    path: "/check-list",
    component: loadable(() =>
      import("../modules/client_checklist/ChecklistTable")
    ),
  },
  {
    path: "/phan-cong",
    component: loadable(() =>
      import("../modules/client_cong-viec-phan-cong/Cong_Viec_Phan_Cong")
    ),
  },
  {
    path: "/chuc-nang",
    component: loadable(() =>
      import("../modules/client_CHUC_NANG/ChucnangList")
    ),
  },
  {
    path: "/cong-viec",
    component: loadable(() =>
      import("../modules/client_cong_viec/cong_viec")
    ),
  },
];
export { clientRouters };
