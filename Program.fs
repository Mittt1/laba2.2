open System

// Функция для ввода целого числа с проверкой
let rec vvod_s_proverkoy (stroka: string) : int =
    printf "%s" stroka
    let input = Console.ReadLine()
    match Int32.TryParse(input) with
    | true, value -> value
    | false, _ -> 
        printfn "Ошибка! Введите целое число."
        vvod_s_proverkoy stroka

// Функция для ввода строки
let VYVSTR (stroka: string) : string =
    printf "%s" stroka
    Console.ReadLine()

// Функция для генерации списка строк с вводом с клавиатуры
let keyboard (n: int) : string list =
    [ 
        for i in 1 .. n do
            printf "Введите элемент списка: "
            yield Console.ReadLine()
    ]

// Функция для генерации списка строк случайным образом
let genrandom (n: int) : string list =
    let rnd = new Random()
    [ 
        for i in 1 .. n do
            let length = rnd.Next(1, 10)
            let chars = [| for i in 1 .. length -> char (rnd.Next(97, 123)) |]
            yield new String(chars)
    ]

// Реализация функции fold 
let rec list_fold (f: 'a -> 'b -> 'a) (acc: 'a) (lst: 'b list) : 'a =
    match lst with
    | [] -> acc
    | head :: tail -> list_fold f (f acc head) tail

// Функция для подсчета строк заданной длины
let count_str (length: int) (lst: string list) : int =
    let countFunc (acc: int) (s: string) =
        if s.Length = length then acc + 1 else acc
    list_fold countFunc 0 lst

// Основная функция программы
let main () =
    printfn "Выберите способ генерации списка:"
    printfn "1. Ввод с клавиатуры"
    printfn "2. Генерация случайным образом"
    let option = vvod_s_proverkoy "Ваш выбор: "

    let lst =
        match option with
        | 1 -> 
            let n = vvod_s_proverkoy "Введите количество элементов списка: "
            keyboard n
        | 2 -> 
            let n = vvod_s_proverkoy "Введите количество элементов списка: "
            genrandom n
        | _ -> 
            printfn "Неверный выбор. Программа завершена."
            []

    if lst <> [] then
        let length = vvod_s_proverkoy "Введите длину строки для подсчета: "
        let count = count_str length lst
        printfn "Исходный список: %A" lst
        printfn "Количество строк длины %d: %d" length count

// Запуск программы
main ()