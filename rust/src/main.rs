fn main() {
    // atoi_tests
    //icecream();
    //power_of_3();
    unique_paths();
    println!("All tests completed successfully");
}
fn unique_paths()
{
    assert_eq!(1, unique_paths_with_obstacles(parse_grid("[0,1],[0,0]")));
    assert_eq!(2, unique_paths_with_obstacles(parse_grid("[0,0,0],[0,1,0],[0,0,0]")));
    assert_eq!(1, unique_paths_with_obstacles(parse_grid("[0]")));
    assert_eq!(0, unique_paths_with_obstacles(parse_grid("[1]")));
    assert_eq!(0, unique_paths_with_obstacles(parse_grid("[1,0]")));
    assert_eq!(11, unique_paths_with_obstacles(parse_grid("[0,0,0,0,0],[0,1,0,0,0],[0,1,0,0,0],[0,0,0,0,0]")));
    
    assert_eq!(
        13594824, 
        unique_paths_with_obstacles(
            parse_grid("[0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,1,0,0],[1,0,0,0,0,0,1,0,0,0,0,0,1,0,1,1,0,1],[0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0],[0,0,0,0,0,1,0,0,0,0,1,1,0,1,0,0,0,0],[1,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0],[0,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0],[0,0,1,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0],[0,1,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0],[0,0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,0,1],[0,1,0,1,0,1,0,0,0,0,0,0,0,1,0,0,0,0],[0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1],[1,0,1,1,0,0,0,0,0,0,1,0,1,0,0,0,1,0],[0,0,0,1,0,0,0,0,1,1,1,0,0,1,0,1,1,0],[0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0],[0,1,1,0,0,1,0,0,0,0,0,0,0,1,1,0,0,0],[0,0,0,0,0,0,1,0,1,0,0,1,0,1,1,1,0,0],[0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,1,1],[0,1,0,0,0,0,0,0,0,0,1,0,1,0,1,0,1,0],[1,0,0,1,0,1,0,0,1,0,0,0,0,0,0,0,0,0],[0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0],[0,1,0,0,0,0,0,1,0,0,0,0,0,0,1,1,1,0],[1,0,1,0,1,0,0,0,0,0,0,1,1,0,0,0,0,1],[1,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,0]")));
}
fn parse_grid(s: &str) -> Vec<Vec<i32>>{

    let mut start = 0;
    let mut vec = Vec::new();
    for (i, c) in s.chars().enumerate() {
        if c == '[' {
            start = i + 1;
        }
        else if c == ']' {
            let sub = &s[start..i];
            let mut row = Vec::new();
            for c2 in sub.chars() {
                if c2 == ',' {
                    continue;
                }
                row.push(c2 as i32 - 48);
            }
            vec.push(row);
        }
    }
    return vec;
}

pub fn unique_paths_with_obstacles(obstacle_grid: Vec<Vec<i32>>) -> i32 {
    if obstacle_grid[0][0] == 1
    {
        return 0;
    }
    return unique_path(0, 0, &obstacle_grid);     
}
pub fn unique_path(row: usize, col: usize, obstacle_grid: &Vec<Vec<i32>>) -> i32 {
    let rows = obstacle_grid.len();
    let cols = obstacle_grid[0].len();
    let mut rv = 0;
    let mut row = row;
    let mut col = col;
    loop {
        if row == rows - 1 && col == cols - 1 {
            return rv + 1;  // we are at the end!
        }
        let down = row < rows - 1 && obstacle_grid[row + 1][col] == 0;
        let right = col < cols - 1 && obstacle_grid[row][col + 1] == 0;
        if !right && !down {
            return rv;
        }
        if right && down {
            rv += unique_path(row, col + 1, &obstacle_grid);    // spawn another path to the right
        }
        if down {
            row = row + 1;  // proceed down
        }
        else {  // proceed right
            col = col + 1;
        }
    }
}

fn power_of_3(){
    assert_eq!(true, is_power_of_three(9));
    assert_eq!(true, is_power_of_three(243));
    assert_eq!(true, is_power_of_three(27));
    assert_eq!(true, is_power_of_three(3));
    assert_eq!(true, is_power_of_three(1));
    
    assert_eq!(false, is_power_of_three(8));
    assert_eq!(false, is_power_of_three(177148));
    assert_eq!(false, is_power_of_three(1594322));
    assert_eq!(false, is_power_of_three(45));
    assert_eq!(false, is_power_of_three(0));
    assert_eq!(false, is_power_of_three(-27));
}
pub fn is_power_of_three(n: i32) -> bool {
    if n <= 0 {
        return false;
    }
    let mut min = 0;
    let mut max = 19;
    let base: i32 = 3;
    loop {

        let guess = ((max - min) / 2) + min;
        let val = base.pow(guess);
        if val == n {
            break true;
        }

        if val > n {
            max = guess - 1;
        } else if val < n {
            min = guess + 1;
        }
        if max < min {
            break false;
        }
    }
}

fn icecream()
{
    assert_eq!(4, max_ice_cream(vec!(1,3,2,4,1), 7));
    assert_eq!(0, max_ice_cream(vec!(10,6,8,7,7,8), 5));
    assert_eq!(6, max_ice_cream(vec!(1,6,3,1,2,5), 20));
}
pub fn max_ice_cream(costs: Vec<i32>, coins: i32) -> i32 {
    let mut sorted = costs;
    sorted.sort();
    let mut remaining = coins;
    let mut rv: i32 = 0;
    for c in sorted {
        if c <= remaining {
            rv = rv + 1;
            remaining = remaining - c;
        } else {
            break;
        }
    }
    rv
}

fn atoi_tests() {
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