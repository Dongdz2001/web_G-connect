import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_CHUC_NANG'
class GC_CHUC_NANGBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_CHUC_NANG' }, props);
        super(_props);
    }

    getAllRef_id_du_an() {
        return this.getAllRef('/link-GC_DU_AN/select');
    }
    getAllRef_id_linh_vuc() {
        return this.getAllRef('/link-GC_DM_LINH_VUC/select');
    }
}
const GC_CHUC_NANGService = new GC_CHUC_NANGBaseService();
export { GC_CHUC_NANGService };
