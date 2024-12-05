module Cart
open Product

type Cart = { Items: list<Product> }

let emptyCart = { Items = [] }

let addToCart product cart =
    { cart with Items = product :: cart.Items }

let removeFromCart productName cart =
    let updatedItems = cart.Items |> List.filter (fun p -> p.Name <> productName)
    { cart with Items = updatedItems }

let calculateTotal cart =
    cart.Items |> List.sumBy (fun p -> p.Price) // F# uses float addition here
