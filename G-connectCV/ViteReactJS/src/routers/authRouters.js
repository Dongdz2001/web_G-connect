import { loadable } from "../shared/utils/loadable";
//import loadable from '@loadable/component'
import DemoLayout from "../layouts/demo/DemoLayout";
import AdminLayout from "../layouts/AdminLayout";
import ClientLayout from "../layouts/ClientLayout";
import TableTimeSheet from 'layouts/table-component/TableTimeSheet';
import IssueLayout from "layouts/IssueLayout";
const authRouters = [
  {
    path: "/*",
    component: loadable(() => import("../layouts/NewLayout")),
  },
  {
    path: "/logout",
    component: loadable(() => import("../modules/logout/Logout")),
  },

  {
    path: "/gallery",
    component: loadable(() => import("../modules/gallery/GalleryManager")),
  },
  {
    path: "/demo-layout",
    component: loadable(() => import("../layouts/DemoLayout")),
  },
  // {
  //     path: '/overview',
  //     component: loadable(() => import('../layouts/overview/OverviewLayout')),
  // },

  // {
  //     path: '/collaborate/*',
  //     component: loadable(() => import('../layouts/collaborate/CollaborateLayout')),
  // },
  // {
  //     path: '/learner/*',
  //     component: LearnerLayout,
  // },
  // {
  //     path: '/cuocthi/*',
  //     component: CuocThiLayout,
  // },
  // {
  //     path: '/tuanthu/*',
  //     component: loadable(() => import('../layouts/tuanthu/TuanThuLayout')),
  // },
  // {
  //     path: '/other/*',
  //     component: loadable(() => import('../layouts/others/OtherLayout')),
  // },

  {
    path: '/issues/*',
    component: IssueLayout,
  },
  {
    path: "/demo/*",
    component: DemoLayout,
  },
  {
    path: "/admin/*",
    component: AdminLayout,
  },
  {
    path: "/client/*",
    component: ClientLayout,
  },
  // link to TimeTableSheet
  {
    path: '/table-component/*',
    component: TableTimeSheet,
  },
  {
    path: '/EditSheetTable/:id',
    component: loadable(() => import('../components/EditSheetTable/EditSheetTable'))
  },
  {
      path: '/TableTimeSheet',
      component: loadable(() => import('../layouts/table-component/TableTimeSheet'))
  },
];
export { authRouters };
