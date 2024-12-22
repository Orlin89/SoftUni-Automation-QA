export const bookService = {
    books: [
        { id: "1", title: "1984", author: "George Orwell", year: 1949, genre: "Dystopian" },
        { id: "2", title: "To Kill a Mockingbird", author: "Harper Lee", year: 1960, genre: "Fiction" },
        { id: "3", title: "The Great Gatsby", author: "F. Scott Fitzgerald", year: 1925, genre: "Classic" }
    ],
    
    // getBooks() - Returns a list of books with status 200
    getBooks() {
        return {
            status: 200,
            data: this.books
        };
    },

    // addBook(book) - Adds a new book to the list. If any field is missing or invalid, returns status 400
    addBook(book) {
        if (!book.id || !book.title || !book.author || !book.year || !book.genre) {
            return {
                status: 400,
                error: "Invalid Book Data!"
            };
        }
        this.books.push(book);
        return {
            status: 201,
            message: "Book added successfully."
        };
    },

    // deleteBook(bookID) - Deletes a book by ID. If not found, returns status 404
    deleteBook(bookID) {
        const bookIndex = this.books.findIndex(book => book.id === bookID);
        if (bookIndex === -1) {
            return {
                status: 404,
                error: "Book Not Found!"
            };
        }
        this.books.splice(bookIndex, 1);
        return {
            status: 200,
            message: "Book deleted successfully."
        };
    },

    // updateBook(oldId, newBook) - Updates an existing book by ID. If not found, returns status 404
    // If new book data is invalid, returns status 400
    updateBook(oldId, newBook) {
        const bookIndex = this.books.findIndex(book => book.id === oldId);
        if (bookIndex === -1) {
            return {
                status: 404,
                error: "Book Not Found!"
            };
        }
        if (!newBook.id || !newBook.title || !newBook.author || !newBook.year || !newBook.genre) {
            return {
                status: 400,
                error: "Invalid Book Data!"
            };
        }
        this.books[bookIndex] = newBook;
        return {
            status: 200,
            message: "Book updated successfully."
        };
    }
};
