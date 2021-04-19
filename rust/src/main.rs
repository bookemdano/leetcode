fn main() {
    assert_eq!(42, my_atoi(String::from("42")));
    println!("All Tests Are Done")
}
pub fn my_atoi(s: String) -> i32 {
    let mut first = true;
    let mut neg = false;
    let mut rv: i64 = 0;
    let min_int: i64 = i32::MIN as i64;
    let max_int: i64 = i32::MAX as i64;
    for c in s.chars() {
        if first {
            if c == ' ' {
                continue;
            }
            first = true;
            if c == '-' {
                neg = true;
                continue;
            } else if c == '+' {
                neg = false;
                continue;
            }
        }
        let v: i64 = ((c as u8) - b'0').into();
        if v < 0 || v > 9 {
            break;
        }
        rv = rv * 10 + v;
        if neg == false && rv == max_int {
            return i32::MAX;
        } else if neg == true && (0 - rv) == min_int {
            return i32::MIN;
        }
    }
    if neg {
        rv = 0 - rv;
    }
    rv as i32
}