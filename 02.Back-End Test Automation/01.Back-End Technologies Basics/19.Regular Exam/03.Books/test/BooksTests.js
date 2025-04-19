import {expect} from 'chai';
import {bookService} from "../function/Books.js";

describe("Book Service Tests", function() {

    describe("getBooks()", function() {
        it("Should return a status 200 and an array of books", function(){
            let response = bookService.getBooks();
            expect(response.status).to.be.equal(200);
            expect(response.data[0]).to.include.all.keys('id', 'title', 'author', 'year', 'genre');
            expect(response.data).to.be.an('array'); 

        })
    });

    describe("addBook()", function() {
        it("Should add a new book successfully", function(){
            let newBook = {id: "5", title: "New", author: "Harper Lee", year: 2022, genre: "Fiction"};
            let response = bookService.addBook(newBook);
            expect(response.status).to.equal(201);
            expect(response.message).to.be.equal("Book added successfully.");
            expect(bookService.books).to.deep.include(newBook);
        })

        it("Should return status 400 when adding a book with missing fields", function(){
            let invalidBook = {title: "New", author: "Harper Lee"};
            let response = bookService.addBook(invalidBook);
            expect(response.status).to.be.equal(400);
            expect(response.error).to.be.equal("Invalid Book Data!");
        })
    });

    describe("deleteBook()", function() {
        it("Should delete a book by id successfully", function(){
            let initialCount = bookService.books.length;
            let addToDeleteBook = {id: "4", title: "New", author: "Harper Lee", year: 2022, genre: "Fiction"};
            bookService.addBook(addToDeleteBook);
            expect(bookService.books.length).to.equal(initialCount + 1);
            let response = bookService.deleteBook("4");
            expect(response.status).to.be.equal(200);
            expect(response.message).to.be.equal("Book deleted successfully.");
            expect(bookService.books.length).to.equal(initialCount);
        })

        it("Should return status 404 when deleting a book with a non-existent id", function(){
            let response = bookService.deleteBook("10");
            expect(response.status).to.be.equal(404);
            expect(response.error).to.be.equal("Book Not Found!");
        })
    });

    describe("updateBook()", function() {
        it("Should update a book successfully", function(){
            let updateBook = {id: "1", title: "1985 is new", author: "George Orwell", year: 1949, genre: "Dystopian"}
            let response = bookService.updateBook("1", updateBook);
            expect(response.status).to.be.equal(200);
            expect(response.message).to.be.equal("Book updated successfully.");
            expect(bookService.books[0].title).to.be.equal("1985 is new");
            expect(bookService.books).to.deep.include(updateBook);
        })

        it("Should return status 404 when updating a non-existent book", function(){
            let updateBook = {id: "1", title: "1985 is new", author: "George Orwell", year: 1949, genre: "Dystopian"}
            let response = bookService.updateBook("20", updateBook);
            expect(response.status).to.be.equal(404);
            expect(response.error).to.be.equal("Book Not Found!");
        })

        it("Should return status 400 when updating with incomplete book data", function(){
            let updateBook = {title: "1985 is new", author: "George Orwell"}
            let response = bookService.updateBook("2", updateBook);
            expect(response.status).to.be.equal(400);
            expect(response.error).to.be.equal("Invalid Book Data!");
        })
    });
});