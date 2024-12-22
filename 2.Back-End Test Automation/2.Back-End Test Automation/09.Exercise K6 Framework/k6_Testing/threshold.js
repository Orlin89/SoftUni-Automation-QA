import http from 'k6/http';
import {sleep} from 'k6';
import {check} from 'k6';

export const options = {
    vus: 10,
    duration: '30s',
    thresholds: {
        'http_req_duration': ['p(90)<3500 ','p(95)<3000'],
        'http_req_failed': ['rate<0.01']
    }
};

export default function(){
    const response = http.get('http://test.k6.io');
    check(response, {
        'HTTP status is 200': (r) => r.status === 200,
        'Homepage welcome header ispresent': (r) => r.body.includes('Welcome to the k6.io demo site!')
    });
    sleep(2);
}