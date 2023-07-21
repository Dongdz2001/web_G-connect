import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-GC_DU_AN'
class GC_DU_ANBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-GC_DU_AN' }, props);
        super(_props);
    }

    getAllRef_id_loai_du_an() {
        return this.getAllRef('/link-GC_DM_LOAI_DU_AN/select');
    }
}
const GC_DU_ANService = new GC_DU_ANBaseService();
export { GC_DU_ANService };
