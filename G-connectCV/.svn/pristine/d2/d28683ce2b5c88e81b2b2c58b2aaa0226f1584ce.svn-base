import axios from 'axios'
import { BaseService } from 'services/BaseService';
import { appSetting } from 'shared/app-settings';

let path = appSetting.PATH_APILMS_V2 + '/link-ClientCorsOrigins'
class ClientCorsOriginsBaseService extends BaseService {
    constructor(props) {
        const _props = Object.assign({}, { url: appSetting.PATH_APILMS_V2 + '/link-ClientCorsOrigins' }, props);
        super(_props);
    }

    getAllRef_ClientId() {
        return this.getAllRef('/link-Clients/select');
    }
}
const ClientCorsOriginsService = new ClientCorsOriginsBaseService();
export { ClientCorsOriginsService };
