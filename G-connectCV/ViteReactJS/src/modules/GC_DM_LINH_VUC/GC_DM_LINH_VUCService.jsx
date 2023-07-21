import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_DM_LINH_VUC'
class GC_DM_LINH_VUCBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_DM_LINH_VUC' }, props);
        super(_props);
    }

    getAllRef_id_linh_vuc_cha() {
        return this.getAllRef('/link-GC_DM_LINH_VUC/select');
    }
}
const GC_DM_LINH_VUCService = new GC_DM_LINH_VUCBaseService();
export { GC_DM_LINH_VUCService };
