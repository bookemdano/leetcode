fn main() {
    assert_eq!(42, my_atoi(String::from("42")));
    assert_eq!(-42, my_atoi(String::from("-42")));
    assert_eq!(-42, my_atoi(String::from("  -42xyz")));
    assert_eq!(0, my_atoi(String::from("not a number")));
    assert_eq!(-2147483648, my_atoi(String::from("-538290538290")));
    assert_eq!(2147483647, my_atoi(String::from("538290538290")));
    assert_eq!(0, my_atoi(String::from("+-12")));
    assert_eq!(-12, my_atoi(String::from("-0012a42")));
    assert_eq!(2147483647, my_atoi(String::from("2147483648")));
    assert_eq!(-2147483648, my_atoi(String::from("-2147483648")));
    assert_eq!(-2147483647, my_atoi(String::from("-2147483647")));
    println!("All Tests Are Done")
}
pub fn my_atoi(s: String) -> i32 {
    let mut first = true;
    let mut neg = false;
    let mut rv: i64 = 0;
    let min_int: i64 = std::i32::MIN as i64;    // need to use the depricated MIN and MAX
    let max_int: i64 = std::i32::MAX as i64;
    for c in s.chars() {
        if first {
            if c == ' ' {
                continue;
            }
            first = false;
            if c == '-' {
                neg = true;
                continue;
            } else if c == '+' {
                neg = false;
                continue;
            }
        }
        if c < '0' || c > '9' {
            break;
        }
        let v: i64 = ((c as u8) - b'0').into();
        rv = rv * 10 + v;
        if neg == false && rv >= max_int {
            return std::i32::MAX;
        } else if neg == true && (0 - rv) <= min_int {
            return std::i32::MIN;
        }
    }
    if neg {
        rv = 0 - rv;
    }
    rv as i32
}