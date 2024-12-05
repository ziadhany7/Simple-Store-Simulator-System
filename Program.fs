open System
open System.Windows.Forms
open Product
open Cart


// Initialize forms
let form = new Form(Text = "Simple Store Simulator", Width = 400, Height = 500)

// Create UI components
let productList = new ListBox(Dock = DockStyle.Top, Height = 150)
let cartList = new ListBox(Dock = DockStyle.Top, Height = 150)
let totalLabel = new Label(Dock = DockStyle.Bottom, Text = "Total: $0.00", Height = 30)

let addButton = new Button(Text = "Add to Cart", Dock = DockStyle.Left, Width = 120)
let removeButton = new Button(Text = "Remove from Cart", Dock = DockStyle.Left, Width = 120)
let checkoutButton = new Button(Text = "Checkout", Dock = DockStyle.Right, Width = 120)

// Initialize the cart
let mutable cart = emptyCart

// Populate product list with name, price, and description
products |> List.iter (fun p -> 
    productList.Items.Add($"{p.Name} - ${p.Price} - {p.Description}") |> ignore
)

// Add to cart event
addButton.Click.Add(fun _ -> 
    if productList.SelectedItem <> null then
        let selectedName = productList.SelectedItem.ToString().Split(" - ").[0]
        match findProductByName selectedName with
        | Some product ->
            cart <- addToCart product cart
            cartList.Items.Add($"{product.Name} - ${product.Price}") |> ignore
        | None -> MessageBox.Show("Product not found!") |> ignore
    else
        MessageBox.Show("Please select a product!") |> ignore
)
