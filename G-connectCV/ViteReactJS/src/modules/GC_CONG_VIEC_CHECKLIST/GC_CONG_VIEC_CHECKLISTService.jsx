import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_CONG_VIEC_CHECKLIST'
class GC_CONG_VIEC_CHECKLISTBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_CONG_VIEC_CHECKLIST' }, props);
        super(_props);
    }

    getAllRef_id_chuc_nang() {
        return this.getAllRef('/link-GC_CHUC_NANG/select');
    }
    getAllRef_id_cong_viec() {
        return this.getAllRef('/link-GC_CONG_VIEC/select');
    }
    getAllRef_id_loai_checklist() {
        return this.getAllRef('/link-GC_DM_LOAI_CHECK_LIST/select');
    }
}
const GC_CONG_VIEC_CHECKLISTService = new GC_CONG_VIEC_CHECKLISTBaseService();
export { GC_CONG_VIEC_CHECKLISTService };
