module Product

type Product = {
    Name: string
    Price: float
    Description: string
}

// Initialize a product catalog
let products = [
    { Name = "Apple"; Price = 1.0; Description = "Fresh red apple, rich in vitamins." }
    { Name = "Bread"; Price = 2.5; Description = "Whole grain bread, freshly baked." }
    { Name = "Milk"; Price = 1.5; Description = "1 liter of milk, full of calcium." }
]

// Get product by name
let findProductByName name =
    products |> List.tryFind (fun p -> p.Name = name)
