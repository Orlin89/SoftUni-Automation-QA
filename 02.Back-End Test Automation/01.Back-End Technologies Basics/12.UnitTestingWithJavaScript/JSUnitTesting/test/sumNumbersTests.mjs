import {expect} from 'chai'
import {sum} from '../functionsESM.mjs'

describe('Sum function tests', function (){
    it("sum single number", function(){
        expect(sum([1])).to.equal(1);
    })
})