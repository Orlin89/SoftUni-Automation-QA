// Импортираме expect от Chai и функцията createCalculator от модула createCalculator.mjs
import { expect } from 'chai';
import { createCalculator } from '../addSubstract.js';

// Описваме тестовете за функцията createCalculator
describe('createCalculator', function() {
    
    let calculator;

    beforeEach(function() {
        calculator = createCalculator();
    });

    // Тест: Проверка дали връща коректно началната стойност
    it('should return 0 as the initial value', function() {
        expect(calculator.get()).to.equal(0); // Очакваме първоначалната стойност да е 0
    });

    // Тест: Проверка дали функцията за добавяне работи коректно
    it('should add numbers correctly', function() {
        calculator.add(5);
        expect(calculator.get()).to.equal(5); // Очакваме резултатът да е 5
    });

    // Тест: Проверка дали функцията за изваждане работи коректно
    it('should subtract numbers correctly', function() {
        calculator.subtract(3);
        expect(calculator.get()).to.equal(-3); // Очакваме резултатът да е -3
    });

    // Тест: Проверка дали работи с числа като текстови стойности
    it('should work with string numbers', function() {
        calculator.add('10');
        expect(calculator.get()).to.equal(10); // Очакваме резултатът да е 10
    });

    // Тест: Проверка дали може да добавя и изважда правилно в комбинация
    it('should add and subtract correctly', function() {
        calculator.add(10);
        calculator.subtract(4);
        expect(calculator.get()).to.equal(6); // Очакваме резултатът да е 6
    });

    // Тест: Проверка дали няма странични ефекти между различни инстанции
    it('should keep independent values for different instances', function() {
        const calculator1 = createCalculator();
        const calculator2 = createCalculator();
        
        calculator1.add(10);
        calculator2.add(5);
        
        expect(calculator1.get()).to.equal(10); // Първият калкулатор трябва да има 10
        expect(calculator2.get()).to.equal(5);  // Вторият калкулатор трябва да има 5
    });

    // Тест: Проверка дали връща NaN при невалидни стойности
    it('should return NaN when invalid value is passed to add', function() {
        calculator.add('abc');
        expect(calculator.get()).to.be.NaN; // Очакваме резултатът да е NaN
    });

    it('should return NaN when invalid value is passed to subtract', function() {
        calculator.subtract('abc');
        expect(calculator.get()).to.be.NaN; // Очакваме резултатът да е NaN
    });
});