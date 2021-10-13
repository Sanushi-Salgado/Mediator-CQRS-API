var url = "https://localhost:44315/customers"

var customersList = document.getElementById("customers-list")
// If not null
if (customersList) {
    fetch(url)
        .then(response => response.json())
        .then(date => displayCustomers(data))
        .catch(ex => {
            alert("Oops! Something went wrong.");
            console.log(ex);
        });
}


function displayCustomers(customers) {
    customers.forEach(customer => {
        let li = document.createElement("li");
        let text = '${customer.first_name}';
        li.appendChild(document.createTextNode(text));
        customersList.appendChild(li);
    })
}